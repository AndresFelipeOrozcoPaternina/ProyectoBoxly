namespace Boxly.Api.Models.DTOs;

public class ResultadoOperacionDto<T>
{
    public bool Exitoso { get; set; }
    public string Mensaje { get; set; } = string.Empty;
    public T? Datos { get; set; }
    public List<string> Errores { get; set; } = new();

    public static ResultadoOperacionDto<T> Ok(T datos, string mensaje = "Operación exitosa")
    {
        return new ResultadoOperacionDto<T>
        {
            Exitoso = true,
            Mensaje = mensaje,
            Datos = datos
        };
    }

    public static ResultadoOperacionDto<T> Fallo(string error, List<string>? erroresAdicionales = null)
    {
        var res = new ResultadoOperacionDto<T>
        {
            Exitoso = false,
            Mensaje = error
        };
        if (erroresAdicionales != null && erroresAdicionales.Count > 0)
        {
            res.Errores.AddRange(erroresAdicionales);
        }
        else
        {
            res.Errores.Add(error);
        }
        return res;
    }
}
