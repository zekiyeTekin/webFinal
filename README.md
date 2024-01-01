----------------------------------------UYGULAMA ÇALIÞMASI------------------------------------
Admin[ userName: adminn, þifre: adminn ],Admin[ userName: zekiyeTekin þifre: 123123 ]
User [ userName: webfinal þifre: webweb] 
  Uygulama ilk çalýþtýrýldýðýnda bizleri login ekraný karþýlayacaktýr.Hesabýnýz
var ise kullanýcý adý ve þifeyi doðru yazýldýðý takdirde bizi anasayfaya yönlendirecek.
Giriþ yapýlmadýðýnda ya da hesap yoksa herhangi bir butona týklanýdýðýnda yine login sayfasýnda kalacaktýr. 
Eðer kullanýcý adý ve þifre hatalý girilirse bizi inputlarýn altýnda uyaran text yazýlarý
karþýlayacktýr. Eðer hesabýmýz yoksa sað üstte register butonuna týklayarak üyelik
oluþturabilirsiniz. Kullanýcý hesabý oluþturulduðunda login olmak için gerekli adýmlar
takip edilir.Çoðu css özelliklerinide wwwroot/css/site.css dosyasýnda yazdýðým kodlarý kullanmak
istediðim alanýn class'ýnda çaðýrarak kullanýyorum.

NOT: Kullanýcýnýn iki rolü vardýr. Admin ve user diye ikisi de veri tabanýnda tutuluyor.
Veritabanýndan deðiþtirilmediði sürerce default olarak user özelliði almýþ oluyor.
Admin'in farký Ek olarak ana sayfaya girdiðinde "Kayýtlý Kullanýcýlar" adýnda butonu
görüyor olmasýdýr.
----------------------------------------BUTON ÇALIÞMASI------------------------------------
Ana Sayfa : Kullanýcýnýn ilk karþýlaþacaðý ekrandýr. Ýletiþim için Týklayýnýz kýsmýna týklarsanýz
linkledin profilime yönlendirecek.

Aksesuarlar: Taký adýnýn, taký fotoðrafýnýn, ücretinin ve açýklamasýnýn olduðu 
tablo bizi karþýlayacak. Dilersek "Sil" butonuna týklayarak halihazýrda var olan
takýlarý silebilirsiniz ya da "Yeni Aksesuar Ekle" butonuna týklayarak taký adýný
açýklamasýný,ücretini ve taký görselini ekleyerek yeni bir aksesuar oluþturup 
"Listeye Geri Dön " butonu ile listeye geri dönüp eklendiðini görebilirsiniz.

Kategoriler: Kategoriler sayfasý da Aksesuarlar sayfasý ile ayný þekilde çalýþýyor
Ek olarak sil butonun yanýnda olan "Düzenle" butonun týklandýðýnda deðiþtirilmek 
istenen kategori adýný düzenleyip güncel halini listeye döndüðünüzde görebilirsiniz.
Düzenlemek istediðiniz ada týlandýðýnda söz konuus olan kategori adý input'un içinde
yazýlý olarak geliyor, üzerinde güncel halini yazýp kaydet butonuna týklayabilirsiniz.

Giyimler: Giyimler sayfasýnda da Kategoriler sayfasýna benzer þekilde çalýþýyor.
Bu sayfadaki fark ise "Yeni Giyim Ekle" butonuna týklandýðýnda karþýmýza çýkan
ad, tür, cinsiyet, Kategori alanlarýný doldururken kategori alanýnda seçeneklerini
Kategoriler sayfasýnda girilen kategori alanlarýndan çekiyor oluþudur.Seçeneklerden 
birini seçmemiz gerekli, eðer istenilen cevap seçenkler arasýnda yoksa navbar bölümünde
olan "Kategoriler" butonuna týklayarak ilgili Kategoriyi eklemeniz gerekecektir.

Kayýtlý Kullanýcýlar: Bu butonu görebilemek için sisteme giren kullancýnýn "Admin"
rolünde olmasý gereklidir. Aksi takdirde butonu göremez. Admin rolünde þu anda 
adminn ve zekiyeTekin, kullanýcýlarý var. Buton özelliði ise veri tabanýnda kayýtlý
olan tüm kulanýcýlarýn kullanýcý adý bilgisini ve email bilgisini listeliyor olmasýdýr.

Kullancý kendi adýna týklarsa: profil bilgilerini dilerse güncelleyebilir.
Ayrý ayrý dilerseniz kullanýcý adýný, dilerseniz de þifreyi güncelleyebilirsiniz.
sayfaya eriþmenizi saðlayan kullanýcý adýnýz inputta yazýlý olarak sizi karþýlayacaktýr.

Logout: Butona týklandýðýnda kullanýcýnýn sayfalara eriþimi gider, tekrar giriþ yapmasý
beklenmektedir.
----------------------------------------PROJEDE EKSÝKLÝKLERÝM------------------------------------
-> Aksesuarlarý sildikten sonra beni 0 olan bir boþ sayfaya yönlendirmesi
-> Taký fotoðrafýný ekledikten sonra düzgün çalýþmasýna raðmen taký fotoðraflarý
listeleme kýsýmýnda gözükmüyor. Ekleme ve silme iþlemlerinde veritabanýna da düzgün
ekleniyor, proje dosyamdaki wwwroot/images klasöründe de normal bir þekilde eklendiðinde
eklenip silindiðinde de klasörden siliniyor. Boyuttan kaynaklandýðýný düþündüðüm
bu sorunu çözemedim.
->
----------------------------------------ÇALIÞMA SÜRECÝ MANTIKÐIM----------------------------
En zorlandýðým alan taký görseli eklemek olduðundan dolayý kodlarý araþtýrýp kendi 
projeme deðiþtirerek entegre etmeye çalýþtým.
-->
" [NotMapped]
  public IFormFile ProfileImage { get; set; }
" kodunu ekleme sebebim, bir HTTP isteði sýrasýnda gönderilen dosya bir 
IFormFile nesnesini temsil etmesi etmeliydi. Bu dosyanýn veritabanýnda sütunu olmadýðýný,
saklanmayacaðýný göstermek için [NotMapped] özelliðini ekledim.
-->
"     [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(TakiViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);
                var taki = new Taki
                {
                    TakiAd = model.TakiAd,
                    Description = model.Description,
                    Price = model.Price,
                    ProfileImagePath = uniqueFileName,
                };
                _db.Add(taki);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        private string UploadedFile(TakiViewModel model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
" 
TakiController'da yer alan bu kod parçasý ise;
TakiViewModel sýnýfýnda tanýmladýðým modeller eðer valid ise 'ModelState.IsValid' doðrulamasýndan
geçiyor.UploadedFile metodu yüklenen dosyayý iþlenmek ve dosya adýnýn benzersiz olmasý için 
kullanýlýr.TakiViewModel içindeki "ProfileImage" özelliði kulanarak dosyayý alýr ve projemde 'images'
klasörüne yükler. Oluþan dosya 'uniqueFileName' deðiþkenine atanýyor. Atanan dosya adý 'uniqueFileName'
, 'Taki' sýnýfýna atanýyor ve 'Taki' özellikleri 'TakiViewModel' içindeki özelliklere göre ayarlanýr.
_db.Add(taki) ile de 'Taki' nesnesini veritabanýna eklemek için kullandým.Deðiþikliklerin hepsinin veritabanýna 
 kaydedilmesini beklyen kod ise 'await _db.SaveChangesAsync()' ifadesidir.'return RedirectToAction(nameof(Index))'
 kodu ise bu eylemlerin 'Index'.chtml'e yönlendirilir. Eðer 'ModelState.Invalid' kontrolünden geçemezse, false dönerse
(TakiViewModel sýnýfýndan bir tanesinin bile Invalid olmasý yeterli) 'return View()' ifadesi ayný görüntüyü döndürerek
formu tekrar gösterir.
-->
TakiController'da bir de bu iþlemleri yaparken Delete metodu için de yazdýðým kod parçasý þu þekildedir:
"     
 public async Task<int> Delete(int id)
        {
            var taki = await _db.Takiler.FindAsync(id);
            if (taki != null)
            {
                string ExitingFile = Path.Combine(webHostEnvironment.WebRootPath, "images", taki.ProfileImagePath);
                System.IO.File.Delete(ExitingFile);
                _db.Takiler.Remove(taki);
                _db.SaveChanges();
            }

            
            return await _db.SaveChangesAsync();
        }
"takýyý veritabanýndan silmeyi ve iliþkili bir dosyayý(taký görselini)silmeyi saðlar. '_db.Takiler.FindAsync(id)' ifadesi,
veritabanýnda istenen ID'ye sahip takýyý bulmak için kullanýlýyor.'if (taki != null)' ifadesi, takýnýn veritabanýnda bulunup 
bulunmadýðýný kontrol eder. eðer null deðilse 'string ExitingFile = Path.Combine(webHostEnvironment.WebRootPath, "images", 
taki.ProfileImagePath);kodu ise, silinecek olan dosyanýn yolunu belirler.'webHostEnvironment.WebRootPath'uygulamanýn kök 
dizinini temsil ediyor.taki.ProfileImagePath ise taký nesnesinin profilden gelen resminin dosya adýný içeriyor.
'System.IO.File.Delete(ExitingFile);'ifadesi, seçilen dosyanýn silinmesini saðlar.'_db.Takiler.Remove(taki);'ifadesi 
deðiþkenlerin veritabanýna kaydedilmesini saðlar. 'return await _db.SaveChangesAsync();' kodu ise yapýlan deðiþikliklerin 
asenkron olarak veritabanýna kaydedilmesini saðlýyor ve deðiþikliklerin sayýsýný döndürüyor.

----------------------------------------LOGÝN VE ÞÝFRELEME ÝÇÝN ÝZLEDÝÐÝM ADIM ----------------------------
--> Cookie Authentication ile kullanýcýlarýn kimlik doðrulamasý ve oturum yönetimi saðlayabilmek için 
kullandým. Kullanýcý giriþ yaptýðýnda girilen kullanýcý adý ve þifre doðrulanýr ve kullanýcýya bir 
çerez (cookie) verilmiþ olur.Bu cookie kullanýcýnýn oturumunun devam edebilmeisni saðlar ve sonraki
isteklerde kullanýcýyý kimlik doðrulama için tanýmýþ oluyor.Password Encryption ile de araþtýrdýðýmda sadece
veritabanýnda saklamak güvenli gelmedi ve bende kullanýcýlarýn þifrelerinin güvenli bir þekilde saklanmasý
için bu yöntemi tercih ettim. 
-->
"  
 [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                //login iþlemleri
                string hashedPassword = DoMD5HashedString(model.Password);

                User user = _db.Users.SingleOrDefault(x => x.UserName.ToLower() == model.UserName.ToLower()
                && x.Password == hashedPassword);

                if (user != null)
                {
                    if (user.Locked)
                    {
                        ModelState.AddModelError(nameof(model.UserName), "Kullanýcý hesabý pasif durumdadýr");
                        return View(model);
                    }
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                    claims.Add(new Claim("UserName", user.UserName.ToString()));
                    claims.Add(new Claim(ClaimTypes.Role, user.Role));
                    claims.Add(new Claim("Email", user.Email.ToString()));

                    ClaimsIdentity identity = new ClaimsIdentity(claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);

                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanýcý adý veya þifre hatalý");

                }


            }
            return View(model);
        }


        private string DoMD5HashedString(String s)
        {
            string md5Salt = _configuration.GetValue<string>("AppSettings:MD5Salt");
            string salted = s + md5Salt;
            string hashed = salted.MD5();
            return hashed;
        }
"
-->
Login metodu 'LoginViewModel' tipindeki model nesnesi alýnýr. LoginViewModel,kullanýcý adý ve þifre bilgilerini
temsil eder.'ModelState.IsValid' kontrolü ile de, doðrulama ture ise;
'DoMD5HashedString(model.Password)' ifadesi ile de, kullanýcýnýn girdiði þifrenin MD5 algoritmasý ile þifreleyebilmeyi saðlar
DoMD5HashedString metodu, þifreyi belirli bir tuzla birleþtirir ve ardýndan MD5 algoritmasýný kullanarak þifreyi hashler.
buradaki en büyük amaç güvenlik açýðý oluþmasýný engellmek.'_db.Users.SingleOrDefault' ifadesi, kullanýcý adý ve þifreyi
doðrulayabilmek için veritabanýnda kullanýcýyý arar.Eðer eþleþiyorsa kullanýcýyý döndürür.Bu araþtýrmalarým sonucu:
ClaimsIdentity'nin taleplerle kimlik oluþturmasý,CookieAuthenticationDefaults.AuthenticationScheme'nin kimlik doðrulama
þemasý belirtiðini, HttpContext.SignInAsync'nin de bu metodu oluþturaný kullanarak da kullanýcýyý oturum açmýþ olarak 
belirler. Çerezleri kullanarak da kimlik doðrulamasý saðlar.Eðer kullanýcýyý bulamazsa, hata mesajý 'ModelState.AddModelError'
'a eklenerek döndürür.'DoMD5HashedString' metodu gelen þifreyi MD5 algoritmasýný kullanarak þifreler.

