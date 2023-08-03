using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Uploaders;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileUploader _fileUploader;

        public CarImageManager(ICarImageDal carImageDal, IFileUploader fileUploader)
        {
            _carImageDal = carImageDal;
            _fileUploader = fileUploader;
        }

        public IResult Add(CarImage carImage, IFormFile file)
        {
            carImage.ImagePath = _fileUploader.Upload(file, "wwwroot/CarImages");
            carImage.Date = DateTime.Now;

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }


        //public IResult Add(CarImage carImage, IFormFile file)
        //{

        //    // Dosya adı oluşturma
        //    string fileName = Guid.NewGuid().ToString();
        //    string[] filenameSplit = file.FileName.Split('.');
        //    string fileExtension = filenameSplit[filenameSplit.Length - 1];
        //    fileName = fileName + "." + fileExtension;

        //    // Define the path to save the file
        //    string filePath = Path.Combine("wwwroot/CarImages", fileName);

        //    // Save the file
        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        file.CopyTo(stream);
        //    }

        //    // carImages nesnesine resmi ekleyelim
        //    carImage.ImagePath = _fileUploader.Upload(file, filePath);

        //    // Veritabanına kaydedelim
        //    _carImageDal.Add(carImage);
        //    return new SuccessResult(Messages.CarImageAdded);
        //}

        public IResult Delete(CarImage carImage)
        {
            _fileUploader.Delete("wwwroot/CarImages" + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<CarImage> GetByImageId(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = _fileUploader.Update(file, "wwwroot/CarImages" + carImage.ImagePath, "wwwroot/CarImages");
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImagesUpdated);
        }
    }
}
