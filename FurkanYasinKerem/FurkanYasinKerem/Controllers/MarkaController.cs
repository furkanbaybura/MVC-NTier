using AutoMapper;
using FurkanYasinKerem.Models;
using Fyk.BLL.Managers.Concrete;
using FykDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.AccessControl;

namespace FurkanYasinKerem.Controllers
{
    public class MarkaController : Controller
    {
        private MarkaManager _markaManager;
        private ModelManager _modelManager;
        private IMapper _mapper;
        private int _rowNum = 1;
        public MarkaController(MarkaManager markaManager, ModelManager modelManager)
        {
            _markaManager = markaManager;
            _modelManager = modelManager;

            MapperConfiguration configuration = new MapperConfiguration(configuration => {
                configuration.CreateMap<MarkaViewModel,MarkaDto>().ForMember(x=> x.Modeller, y=> y.MapFrom(z=> z.Modeller));
                configuration.CreateMap<ModelViewModel, ModelDto>().ForMember(x => x.Marka, y => y.MapFrom(z => z.Marka));
                
                configuration.CreateMap<ModelViewModel,ModelDto>().ReverseMap();
            });
            _mapper = configuration.CreateMapper();
        }
        public IActionResult Index()
        {
            List<MarkaDto> markaDtos = _markaManager.GetAll().ToList();
            List<MarkaViewModel> models = new List<MarkaViewModel>();

            foreach (MarkaDto markaDto in markaDtos)
            {
                MarkaViewModel markaView = new MarkaViewModel();
                markaView = _mapper.Map<MarkaViewModel>(markaDto);
                models.Add(markaView);
                markaView.RowNum++;
            }
            return View(models);
        }
        [HttpGet]
        public IActionResult Add() 
        {
            MarkaViewModel viewModel = new MarkaViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(MarkaViewModel model) 
        { 
            
            if (model.logoResim is not null)
            {
                var konum = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", model.logoResim.FileName);

                //Kaydetmek için bir akış ortamı oluşturalım
                var akisOrtami = new FileStream(konum, FileMode.Create);

                //Resmi kaydet
                model.logoResim.CopyTo(akisOrtami);

                MarkaDto dto = _mapper.Map<MarkaDto>(model);
                _markaManager.Add(dto);
                return RedirectToAction("Index");
            }
            return View(); 
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            MarkaDto markaDto = _markaManager.GetById(id);
            MarkaViewModel vm = _mapper.Map<MarkaViewModel>(markaDto);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Delete(MarkaViewModel model)
        {
            MarkaDto dto = _mapper.Map<MarkaDto>(model);
            _markaManager.Delete(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            MarkaDto dto = _markaManager.GetById(id);
            

            MarkaViewModel vm = _mapper.Map<MarkaViewModel>(dto);

            
            if (vm.logoAd == null)
            {
                vm.logoAd = dto.logoAd;

            }
            ViewBag.PicName = vm.logoAd;

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(MarkaViewModel model)
        {
            if (model.logoResim is null)
            {
                ModelState.Remove<MarkaViewModel>(m => m.logoResim);
            }


            //ModelState.Remove<MarkaViewModel>(m => m.Modeller);
            //ModelState.Remove<MarkaViewModel>(m => m.RowNum);


            if (ModelState.IsValid)
            {
                if (model.logoResim != null && model.logoResim.Name != model.logoAd)
                {
                    model.logoAd = model.logoResim.FileName;

                    var konum = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", model.logoResim.FileName);

                    //Kaydetmek için bir akış ortamı oluşturalım
                    var akisOrtami = new FileStream(konum, FileMode.Create);

                    //Resmi kaydet
                    model.logoResim.CopyTo(akisOrtami);
                }
                MarkaDto dto = _mapper.Map<MarkaDto>(model);
                _markaManager.Update(dto);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Detail(int id )
        {
            MarkaDto dto = _markaManager.GetById(id);
            MarkaViewModel model = _mapper.Map<MarkaViewModel>(dto);

            if (dto.Modeller != null)
            {

                ViewBag.DtoList = dto.Modeller.ToList();
            }

            return View(model);
        }
    }
}
