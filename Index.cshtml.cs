using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nest;
using RESTAPISMART.Controllers;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static RESTAPISMART.Entity.Models;

namespace RESTAPISMART
{

    public class IndexModel : PageModel
    {
        private readonly IPropRepo _propRepo;

        public IndexModel(IPropRepo _propRepo)
        {
            this._propRepo = _propRepo;
        }


        [BindProperty]
        public string searchPhrase { get; set; }

        [BindProperty]
        public string Market { get; set; }

        //public IEnumerable<Property> properties { get; set; }

        public Searcher searcher{ get; set; }





        public async Task<IActionResult> OnGetSearch()
        {

            var Mrkt = await _propRepo.GetPropertyByMarket(Market);

            searcher.searchPhrase = searchPhrase;
            if (searchPhrase != null)
            {
                await _propRepo.GetProperties(searchPhrase);
                await _propRepo.GetProperty(searchPhrase);
                await _propRepo.GetPropertyByMarket(Mrkt.market);
                await _propRepo.GetPropertyByCity(searchPhrase);
            }
            
            return Page();
        }
    }
}
