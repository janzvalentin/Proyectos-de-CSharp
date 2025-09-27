using Sistema_de_Gestión_de_Estudiantes_Universitarios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_Estudiantes_Universitarios.Modelos
{
    public abstract class PersonaBase : IPersona
    {
        protected string _nombre { get; set; }
        protected string _identificacion { get; set; }
        protected DateTime _fechaNacimiento { get; set; }

        protected PersonaBase(string nombre, string identificacion, DateTime fechaNacimiento)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede estar vacío", nameof(nombre));

            if (string.IsNullOrWhiteSpace(identificacion))
                throw new ArgumentException("La identificación no puede estar vacío", nameof(identificacion));

            if (fechaNacimiento > DateTime.Now)
                throw new ArgumentException("La fecha de nacimiento no puede ser futura", nameof(fechaNacimiento));

            _nombre = nombre;
            _identificacion = identificacion;
            _fechaNacimiento = fechaNacimiento;
        }

        public string Nombre
        {
            get => _nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre no puede estar vacío", nameof(Nombre));
                _nombre = value;
            }
        }
        public string Identificacion
        {

            get => _identificacion;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("La identificación no puede estar vacÍo", nameof(Identificacion));
                _identificacion = value;
            }
        }
        public DateTime FechaNacimiento
        {
            get => _fechaNacimiento;
            set
            {
                if (value > _fechaNacimiento)
                    throw new ArgumentException("La fecha de nacimiento no puede ser futura", nameof(FechaNacimiento));
                _fechaNacimiento = value;
            }
        }
        public int CalcularEdad()
        {
            var hoy = DateTime.Today;
            int edad = hoy.Year - _fechaNacimiento.Year;
            if (hoy.DayOfYear < _fechaNacimiento.DayOfYear) edad--;
            return edad;
        }

        public abstract string ObtenerInformacionCompleta();

    }
}
