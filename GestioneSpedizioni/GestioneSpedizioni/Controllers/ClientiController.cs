using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using GestioneSpedizioni.Models;
using GestioneSpedizioni.Data;

[Authorize]
public class ClientiController : Controller
{
    private readonly DatabaseHelper _dbHelper;

    public ClientiController(DatabaseHelper dbHelper)
    {
        _dbHelper = dbHelper;
    }

    // Azioni per CRUD
    public async Task<IActionResult> Index()
    {
        var clienti = new List<Cliente>();
        using (var connection = _dbHelper.GetConnection())
        {
            await connection.OpenAsync();
            var command = new SqlCommand("SELECT * FROM Clienti", connection);
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    clienti.Add(new Cliente
                    {
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Cognome = reader.GetString(2),
                        CodiceFiscale = reader.IsDBNull(3) ? null : reader.GetString(3),
                        RagioneSociale = reader.IsDBNull(4) ? null : reader.GetString(4),
                        PartitaIVA = reader.IsDBNull(5) ? null : reader.GetString(5),
                        Email = reader.GetString(6),
                        Telefono = reader.GetString(7),
                        Indirizzo = reader.GetString(8)
                    });
                }
            }
        }
        return View(clienti);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Cliente cliente)
    {
        if (ModelState.IsValid)
        {
            using (var connection = _dbHelper.GetConnection())
            {
                await connection.OpenAsync();
                var command = new SqlCommand("INSERT INTO Clienti (Nome, Cognome, CodiceFiscale, RagioneSociale, PartitaIVA, Email, Telefono, Indirizzo) VALUES (@Nome, @Cognome, @CodiceFiscale, @RagioneSociale, @PartitaIVA, @Email, @Telefono, @Indirizzo)", connection);
                command.Parameters.AddWithValue("@Nome", cliente.Nome);
                command.Parameters.AddWithValue("@Cognome", cliente.Cognome);
                command.Parameters.AddWithValue("@CodiceFiscale", (object)cliente.CodiceFiscale ?? DBNull.Value);
                command.Parameters.AddWithValue("@RagioneSociale", (object)cliente.RagioneSociale ?? DBNull.Value);
                command.Parameters.AddWithValue("@PartitaIVA", (object)cliente.PartitaIVA ?? DBNull.Value);
                command.Parameters.AddWithValue("@Email", cliente.Email);
                command.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                command.Parameters.AddWithValue("@Indirizzo", cliente.Indirizzo);
                await command.ExecuteNonQueryAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        return View(cliente);
    }
}
