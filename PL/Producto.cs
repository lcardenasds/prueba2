using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Producto
    {
        //INSERT
        public static void Add()
        {
            ML.Producto producto = new ML.Producto();
            
            Console.WriteLine("Ingrese el Nombre del Producto");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese la Descripcion del Producto");
            producto.Descripcion = Console.ReadLine();

            Console.WriteLine("Ingrese el Proveedor del Producto");
            producto.Proveedor = Console.ReadLine();

            Console.WriteLine("Ingrese el Existencia del Producto");
            producto.Existencia = int.Parse(Console.ReadLine());

            ML.Result result = BL.Producto.Add(producto);
            if (result.Correct)
            {
                Console.WriteLine("El producto se insertó correctamente");
            }
            else
            {
                Console.WriteLine("El producto no pudo ser insertado correctamente " + result.ErrorMessage);
            }
        }
        //UPDATE
        public static void Update()
        {
            ML.Producto producto = new ML.Producto();
            Console.WriteLine("Elija el registro que desea actualizar");
             producto.IdProducto = int.Parse(Console.ReadLine());

             Console.WriteLine("Actualize el Nombre del Producto");
             producto.Nombre = Console.ReadLine();

             Console.WriteLine("Actualize la Descripcion del Producto");
             producto.Descripcion = Console.ReadLine();

             Console.WriteLine("Actualize el Proveedor del Producto");
             producto.Proveedor = Console.ReadLine();

             Console.WriteLine("Actualize el Existencia del Producto");
             producto.Existencia = int.Parse(Console.ReadLine());

             ML.Result result = BL.Producto.Update(producto);
             if (result.Correct)
             {
                 Console.WriteLine("El producto se actualizo correctamente");
             }
             else
             {
                 Console.WriteLine("El producto no se pudo ser actualizado correctamente " + result.ErrorMessage);
             }
        }
        //DELETE
        public static void Delete()
        {
            ML.Producto producto = new ML.Producto();
            Console.WriteLine("Elija el registro que desea eliminar");
            producto.IdProducto = int.Parse(Console.ReadLine());

            ML.Result result = BL.Producto.Delete(producto);
            if (result.Correct)
            {
                Console.WriteLine("El producto se elimino correctamente");
            }
            else
            {
                Console.WriteLine("El producto no pudo ser eliminado correctamente " + result.ErrorMessage);
            }
        }
        //GETALL
        public static void GetAll()
        {
            ML.Producto producto = new ML.Producto();
            Console.WriteLine("Productos");
            Console.WriteLine("Id:\t Nombre: \t\tDescripción: \t\tProveedor: \tExistencias:");
           
            ML.Result result = BL.Producto.GetAll(producto);
            if (result.Correct)
            {
                Console.WriteLine("El producto se mostro correctamente");
            }
            else
            {
                Console.WriteLine("El producto no pudo ser mostrado correctamente " + result.ErrorMessage);
            }
        }
        //GETBYID
        public static void GetById()
        {
            ML.Producto producto = new ML.Producto();
            Console.WriteLine("Producto");
            Console.WriteLine("Elija el registro que desea revisar");           
            producto.IdProducto = int.Parse(Console.ReadLine());
       
             Console.WriteLine("Id:\t Nombre: \t\tDescripción: \t\tProveedor: \tExistencias:");
            ML.Result result = BL.Producto.GetById(producto);
            if (result.Correct)
            {
                Console.WriteLine("El producto se mostro correctamente");
            }
            else
            {
                Console.WriteLine("El producto no pudo ser mostrado correctamente " + result.ErrorMessage);
            }
        }
    }
}
