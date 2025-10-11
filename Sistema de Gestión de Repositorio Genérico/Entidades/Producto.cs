using Sistema_de_Gestión_de_Repositorio_Genérico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_Repositorio_Genérico.Entidades
{
    public class Producto : IIdentificable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        private double _precio;
        public double Precio
        {
            get => _precio;
            set
            {
                if (value <= 0) throw new ArgumentException("El precio debe ser mayor que 0.");
                _precio = value;
            }
        }

        private int _stock;
        public int Stock
        {
            get => _stock;
            set
            {
                if (value < 0) throw new ArgumentException("El stock no puede ser negativo.");
                _stock = value;
            }
        }

        public Producto(int id, string nombre, double precio, int stock)
        {
            if (id <= 0) throw new ArgumentException("Id debe ser mayor que 0.");
            if (precio <= 0) throw new ArgumentOutOfRangeException(nameof(precio), "Precio debe ser mayor que 0.");
            if (stock < 0) throw new ArgumentOutOfRangeException(nameof(stock), "Stock no puede ser negativo.");
            Id = id; Nombre = nombre; Precio = precio; Stock = stock;
        }
        //Implementación del méto exigido por la interfaz IIdentificable
        public string ObtenerDescripcion()
        {
            return $"ID: {Id}, Nombre: {Nombre}, Precio: {Precio:c}, Stock: {Stock}";
        }
    }
}
