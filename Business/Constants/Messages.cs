using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string ProductAdded = "Ekleme işlemi başarılı";
        public static string ProductDeleted = "Silme işlemi başarılı";
        public static string ProductUpdated = "Güncelleme işlemi başarılı";
        public static string ProductNameInvalid = "İsim geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed = "Listeleme işlemi başarılı";


        public static string ImageLimitExceeded = "Resim ekleme sınırına ulaşıldı";
        public static string NotFound = "Böyle bir şey bulunamıyor";

        public static string UserRegistered = "Kayıt başarılı";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatalı";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı zaten kayıtlı";
        public static string AccessTokenCreated = "Token üretildi";
        public static string AuthorizationDenied = "Yetki reddedildi.";

        public static string creditCardAdded = "Kredi kartı eklendi.";
        public static string creditCardDeleted = "Kredi kartı silindi.";

        public static string PaymentFailed = "Ödeme başarısız.";
        public static string PaymentSuccessful = "Ödeme başarılı.";

        public static string RentalNotAvailable = "Seçilen tarihler için kiralama yapılamaz.";
        public static string RentError = "Araba zaten kiralanmış";
        public static string RentalUndeliveredCar = "Araba henüz teslim edilmedi.";

        public static string OperationClaimAdded = "Operasyon yetkisi eklendi.";
        public static string OperationClaimUpdated = "Operasyon yetkisi güncellendi.";
        public static string OperationClaimDeleted = "Operasyon yetkisi silindi.";

        public static string UserOperationClaimAdded = "Kullanıcıya yetki verildi.";
        public static string UserOperationClaimUpdated = "Kullanıcının yetkisi güncellendi.";
        public static string UserOperationClaimDeleted = "Kullanıcının yetkisi silindi.";
    }
}
