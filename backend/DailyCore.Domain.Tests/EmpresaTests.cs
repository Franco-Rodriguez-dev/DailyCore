using DailyCore.Domain.Entities;

namespace DailyCore.Domain.Tests;

public class EmpresaTests
{
    [Fact]
    public void Constructor_NombreConEspacios_GuardaNombreSinEspacios()
    {
       
        // Preparar
        var nombre = "  Almacén  ";

        // Actuar
        // Creá una Empresa usando nombre.
        var empresa = new Empresa(nombre);



        // Comprobar
        // Verificá que empresa.Nombre sea "Almacén".
        Assert.Equal("Almacén", empresa.Nombre);

    }

    [Fact]
    public void Constructor_NombreSoloEspacios_LanzaArgumentException()
    {
        var nombre = "   ";

        // Comprobá que crear la empresa lance ArgumentException.
        Assert.Throws<ArgumentException>(() => new Empresa(nombre));
    }

    [Fact]
    public void Constructor_NombreDe100Caracteres_AceptaNombre()
    {
        // Preparar
        var nombre = new string('A', 100);
        // Actuar
        var empresa = new Empresa(nombre);
        // Comprobar
        Assert.Equal(nombre, empresa.Nombre);
    }

    [Fact]
    public void Constructor_NombreDe101Caracteres_LanzaArgumentException()
    {
        // Preparar
        var nombre = new string('A', 101);
        // Comprobar
        Assert.Throws<ArgumentException>(() => new Empresa(nombre));
    }

    [Fact]
    public void CambiarNombre_NombreDe101Caracteres_ConservaNombreAnterior()
    {
        var empresa = new Empresa("Almacen");

        // Preparar
        var nuevoNombre = new string('A', 101);

        // Actuar y comprobar la excepción
        Assert.Throws<ArgumentException>(() => empresa.CambiarNombre(nuevoNombre));

        // Comprobar que el nombre anterior se conserva
        Assert.Equal("Almacen", empresa.Nombre);
    }

    [Fact]
    public void CambiarNombre_NombreValidoConEspacios_ActualizaNombreSinEspacios()
    {
        // Preparar: crear una empresa llamada "Almacén".
        var empresa = new Empresa("Almacen");

        // Actuar: cambiar su nombre a "  Kiosco  ".
        empresa.CambiarNombre("  kiosco  ");

        // Comprobar: su Nombre debe ser "Kiosco".
        Assert.Equal("kiosco", empresa.Nombre);
    }


}
