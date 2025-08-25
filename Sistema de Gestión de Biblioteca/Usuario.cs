using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_Biblioteca
{
    public class Usuario
    {
        private string nombre;
        private int numeroIdentificacion;
        private MaterialBase[] materialesPrestados;
        private int cantidadPrestamos;
        private int limitePrestamos;
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    nombre = value.Trim();
                }
                else
                {
                    nombre = "SIN NOMBRE";
                }
            }
        }
        public int NumeroIdentificacion
        {
            get { return numeroIdentificacion; }
            set
            {
                if (value > 0)
                {
                    numeroIdentificacion = value;
                }
                else
                {
                    numeroIdentificacion = 1;
                }
            }
        }
        public int LimitePrestamos
        {
            get { return limitePrestamos; }
            set
            {
                if (value > 0)
                {
                    limitePrestamos = value;
                }
                else
                {
                    limitePrestamos = 1;
                }
            }
        }
        public Usuario(string nombre, int id)
        {
            this.Nombre = nombre;
            this.numeroIdentificacion = id;
            this.LimitePrestamos = 3;
            this.materialesPrestados = new MaterialBase[this.limitePrestamos];
            this.cantidadPrestamos = 0;
        }
        public Usuario(string nombre, int id, int limitePrestamos)
        {
            this.Nombre = nombre;
            this.numeroIdentificacion = id;
            this.LimitePrestamos = limitePrestamos;
            this.materialesPrestados = new MaterialBase[this.limitePrestamos];
            this.cantidadPrestamos = 0;
        }
        public int CantidadPrestamos
        {
            get { return cantidadPrestamos; }
            private set { cantidadPrestamos = value; }
        }

        //Verificar si puede prestar
        public bool PuedePrestar()
        {
            return cantidadPrestamos < limitePrestamos;
        }
        //Prestar material
        public void PrestarMaterial(MaterialBase materialBase)
        {
            if (!PuedePrestar())
            {
                Console.WriteLine($"{Nombre} alcanzo el limite de prestamos.");
                return;
            }
            if (!materialBase.Disponible)
            {
                Console.WriteLine($"El material {materialBase.Titulo} ya esta prestado.");
                return;
            }

            materialesPrestados[cantidadPrestamos] = materialBase;
            cantidadPrestamos++;
            materialBase.Prestar();
            Console.WriteLine($"{Nombre} prestó {materialBase.Titulo}.");
        }
        public void DevolverMaterial(MaterialBase materialBase)
        {
            bool encontrado = false;
            for (int i = 0; i < cantidadPrestamos; i++)
            {
                if (materialesPrestados[i] == materialBase)
                {
                    materialBase.Devolver();

                    //Compacttamos el array
                    for (int j = 0; i < cantidadPrestamos - 1; j++)
                    {
                        materialesPrestados[j] = materialesPrestados[j - 1];
                    }
                    materialesPrestados[cantidadPrestamos - 1] = null;
                    cantidadPrestamos--;

                    Console.WriteLine($"{Nombre} devolvió '{materialBase.Titulo}'.");
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine($"{Nombre} no tiene prestado '{materialBase.Titulo}'.");
            }
        }
        //Calcular multas pendientes de un usuario
        public void CalcularMultas()
        {
            Console.WriteLine($"\nMultas pendientes de {Nombre}:");

            if (cantidadPrestamos == 0)
            {
                Console.WriteLine(" - No tiene materiales prestados.");
                return;
            }

            double totalMulta = 0.0;

            for (int i = 0; i < cantidadPrestamos; i++)
            {
                MaterialBase material = materialesPrestados[i];
                if (material != null)
                {
                    Console.Write($"Días de retraso para '{material.Titulo}': ");
                    if (!int.TryParse(Console.ReadLine(), out int dias) || dias < 0)
                    {
                        dias = 0; // valor por defecto si ponen algo inválido
                    }


                    double multa = material.CalcularMulta(dias);
                    Console.WriteLine($"   Multa: S/. {multa:0.00}");

                    totalMulta += multa;
                }
            }

            Console.WriteLine($"TOTAL a pagar por {Nombre}: S/. {totalMulta:0.00}");
        }

        //Mostrar historial de préstamos actuales
        public void MostrarHistorial()
        {
            Console.WriteLine($"\nHistorial de préstamos de {Nombre}:");

            if (cantidadPrestamos == 0)
            {
                Console.WriteLine(" - No tiene materiales prestados actualmente.");
                return;
            }

            for (int i = 0; i < cantidadPrestamos; i++)
            {
                if (materialesPrestados[i] != null)
                {
                    Console.WriteLine($" - {materialesPrestados[i].Titulo} ({materialesPrestados[i].Autor})");
                }
            }
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Usuario: {Nombre} | ID: {NumeroIdentificacion}");
            Console.WriteLine($"Prestamos actuales: {cantidadPrestamos}/{LimitePrestamos}");
            Console.WriteLine("Materiales prestados:");

            if (cantidadPrestamos == 0)
            {
                Console.WriteLine("  Ninguno  ");
            }
            else
            {
                for (int i = 0; i < cantidadPrestamos; i++)
                {
                    Console.WriteLine("  - " + materialesPrestados[i].ObtenerInformacion());
                }
            }

        }
    }
}
