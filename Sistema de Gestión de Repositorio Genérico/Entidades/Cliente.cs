using Sistema_de_Gestión_de_Repositorio_Genérico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_Repositorio_Genérico.Entidades
{
    public class Cliente : IIdentificable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                // Validación simple de formato de email.
                if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                {
                    throw new ArgumentException("El formato del email no es válido.");
                }
                _email = value;
            }
        }
        public DateTime FechaRegistro { get; set; }

        public Cliente(int id, string nombre, string email, DateTime fechaRegistro)
        {
            if (id <= 0) throw new ArgumentException("Id debe ser mayor que 0.");
            if (string.IsNullOrEmpty(email) || !email.Contains("@")) throw new FormatException("Email inválido.");
            Id = id; Nombre = nombre; Email = email; FechaRegistro = fechaRegistro;
        }

        public string ObtenerDescripcion()
        {
            return $"ID: {Id}, Nombre: {Nombre}, Email: {Email}, Registrado el: {FechaRegistro}";
        }
    }
}
