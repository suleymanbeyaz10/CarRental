using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi.";
        public static string CarNameInvalid = "Araba ismi geçersiz. (2 karakter veya daha az)";
        public static string MaintenanceTime = "Sistem bakımda.";
        public static string CarsListed = "Arabalar listelendi.";
        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UserDeleted = "Kullanıcı silindi.";
        public static string UserUpdated = "Kullanıcı güncellendi.";
        public static string UserNameInvalid = "Kullanıcı ismi geçersiz. (2 karakter veya daha az)";
        public static string RentedCar = "Kullanıcı ismi geçersiz. (2 karakter veya daha az)";
        public static string CustomerAdded = "Müşteri eklendi.";
        public static string CustomerDeleted = "Müşteri silindi.";
        public static string CustomerUpdated = "Müşteri güncellendi.";
        public static string CarImageAdded = "Ürün resmi eklendi.";
        public static string CarImageDeleted = "Ürün resmi silindi.";
        public static string CarImagesUpdated = "Ürün resmi güncellendi.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Hatalı şifre.";
        public static string SuccessfulLogin = "Giriş başarılı.";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut.";
        public static string UserRegistered = "Kullanıcı kayıt edildi.";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu.";
        public static string AuthorizationDenied  = "Yetkiniz yok.";
        public static string CarImageFailedToLoad = "Resim yüklenemedi.";
    }
}
