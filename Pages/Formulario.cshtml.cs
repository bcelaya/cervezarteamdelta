using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace testingapp.Pages;

public class FormularioModel : PageModel
{
    private readonly ILogger<FormularioModel> _logger;

    public FormularioModel(ILogger<FormularioModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }

    public void OnClick()
    {
        //Recoger los datos que necesites
        // LLame a la función de insertar los ratos
    }
}

