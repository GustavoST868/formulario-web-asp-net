using System.Data;
using System.Reflection;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        public class PersonData
        {
            public string? name { get; set; }
            public string? cpf { get; set; }
            public string? rg { get; set; }
            public string? e_mail { get; set; }
            public DateTime dateBirth { get; set; }
            public string? gender { get; set; }
            public string? nationality { get; set; }
            public string? maritalStatus { get; set; }
        }

        [HttpGet]
        public IActionResult GetPessoa()
        {
            
            var dbHelper = new DatabaseHelper("localhost", "Formulario", "postgres ", "123456");

            
            DataTable pessoas = dbHelper.GetPessoas();

            
            foreach (DataRow row in pessoas.Rows)
            {
                Console.WriteLine($"ID: {row["id"]}, Nome: {row["name"]}, Email: {row["e_mail"]}, CPF: {row["cpf"]}, RG: { row["rg"]}");
            }
            return Ok(pessoas);
        }

        [HttpPost]
        public IActionResult PostPeople([FromBody] PersonData data)

        {
            var dbHelper = new DatabaseHelper("localhost", "Formulario", "postgres ", "123456");
            bool sucesso = dbHelper.InsertPessoa(data.name, data.cpf, data.rg, data.e_mail, data.dateBirth, data.gender, data.nationality, data.maritalStatus);

            if (sucesso)
            {
                Console.WriteLine("Registro inserido com sucesso!");
                return Ok("Dados adicionados com sucesso!");
            }
            else
            {
                Console.WriteLine("Falha ao inserir o registro.");
                return BadRequest("Erro no PostPeople!");
            }
            
        }

        public class delete_people
        {
            public string? cpf { get; set; }
        }

        [HttpDelete]
        public IActionResult DeletePessoa(delete_people data)
        {
            var dbHelper = new DatabaseHelper("localhost", "Formulario", "postgres ", "123456");
            bool sucesso = dbHelper.deletePeople(data.cpf);
            if (sucesso)
            {
                return Ok("Sucesso em deletar os dados");
            }
            else {
                return BadRequest("Erro ao deletar os dados");
            }
        }

        [HttpPut]
        public IActionResult EditPeople(PersonData data)
        {
            var dbHelper = new DatabaseHelper("localhost", "Formulario", "postgres ", "123456");
            bool sucesso = dbHelper.EditPeople(data.name, data.cpf, data.rg, data.e_mail, data.dateBirth, data.gender, data.nationality, data.maritalStatus);
            if (sucesso)
            {
                return Ok("Dados editados com sucesso");
            }
            else
            {
                return BadRequest("Erro ao editar os dados");
            }
        }
    }
}
