----------------------------------------UYGULAMA �ALI�MASI------------------------------------
Admin[ userName: adminn, �ifre: adminn ],Admin[ userName: zekiyeTekin �ifre: 123123 ]
User [ userName: webfinal �ifre: webweb] 
  Uygulama ilk �al��t�r�ld���nda bizleri login ekran� kar��layacakt�r.Hesab�n�z
var ise kullan�c� ad� ve �ifeyi do�ru yaz�ld��� takdirde bizi anasayfaya y�nlendirecek.
Giri� yap�lmad���nda ya da hesap yoksa herhangi bir butona t�klan�d���nda yine login sayfas�nda kalacakt�r. 
E�er kullan�c� ad� ve �ifre hatal� girilirse bizi inputlar�n alt�nda uyaran text yaz�lar�
kar��layackt�r. E�er hesab�m�z yoksa sa� �stte register butonuna t�klayarak �yelik
olu�turabilirsiniz. Kullan�c� hesab� olu�turuldu�unda login olmak i�in gerekli ad�mlar
takip edilir.�o�u css �zelliklerinide wwwroot/css/site.css dosyas�nda yazd���m kodlar� kullanmak
istedi�im alan�n class'�nda �a��rarak kullan�yorum.

NOT: Kullan�c�n�n iki rol� vard�r. Admin ve user diye ikisi de veri taban�nda tutuluyor.
Veritaban�ndan de�i�tirilmedi�i s�rerce default olarak user �zelli�i alm�� oluyor.
Admin'in fark� Ek olarak ana sayfaya girdi�inde "Kay�tl� Kullan�c�lar" ad�nda butonu
g�r�yor olmas�d�r.
----------------------------------------BUTON �ALI�MASI------------------------------------
Ana Sayfa : Kullan�c�n�n ilk kar��la�aca�� ekrand�r. �leti�im i�in T�klay�n�z k�sm�na t�klarsan�z
linkledin profilime y�nlendirecek.

Aksesuarlar: Tak� ad�n�n, tak� foto�raf�n�n, �cretinin ve a��klamas�n�n oldu�u 
tablo bizi kar��layacak. Dilersek "Sil" butonuna t�klayarak halihaz�rda var olan
tak�lar� silebilirsiniz ya da "Yeni Aksesuar Ekle" butonuna t�klayarak tak� ad�n�
a��klamas�n�,�cretini ve tak� g�rselini ekleyerek yeni bir aksesuar olu�turup 
"Listeye Geri D�n " butonu ile listeye geri d�n�p eklendi�ini g�rebilirsiniz.

Kategoriler: Kategoriler sayfas� da Aksesuarlar sayfas� ile ayn� �ekilde �al���yor
Ek olarak sil butonun yan�nda olan "D�zenle" butonun t�kland���nda de�i�tirilmek 
istenen kategori ad�n� d�zenleyip g�ncel halini listeye d�nd���n�zde g�rebilirsiniz.
D�zenlemek istedi�iniz ada t�land���nda s�z konuus olan kategori ad� input'un i�inde
yaz�l� olarak geliyor, �zerinde g�ncel halini yaz�p kaydet butonuna t�klayabilirsiniz.

Giyimler: Giyimler sayfas�nda da Kategoriler sayfas�na benzer �ekilde �al���yor.
Bu sayfadaki fark ise "Yeni Giyim Ekle" butonuna t�kland���nda kar��m�za ��kan
ad, t�r, cinsiyet, Kategori alanlar�n� doldururken kategori alan�nda se�eneklerini
Kategoriler sayfas�nda girilen kategori alanlar�ndan �ekiyor olu�udur.Se�eneklerden 
birini se�memiz gerekli, e�er istenilen cevap se�enkler aras�nda yoksa navbar b�l�m�nde
olan "Kategoriler" butonuna t�klayarak ilgili Kategoriyi eklemeniz gerekecektir.

Kay�tl� Kullan�c�lar: Bu butonu g�rebilemek i�in sisteme giren kullanc�n�n "Admin"
rol�nde olmas� gereklidir. Aksi takdirde butonu g�remez. Admin rol�nde �u anda 
adminn ve zekiyeTekin, kullan�c�lar� var. Buton �zelli�i ise veri taban�nda kay�tl�
olan t�m kulan�c�lar�n kullan�c� ad� bilgisini ve email bilgisini listeliyor olmas�d�r.

Kullanc� kendi ad�na t�klarsa: profil bilgilerini dilerse g�ncelleyebilir.
Ayr� ayr� dilerseniz kullan�c� ad�n�, dilerseniz de �ifreyi g�ncelleyebilirsiniz.
sayfaya eri�menizi sa�layan kullan�c� ad�n�z inputta yaz�l� olarak sizi kar��layacakt�r.

Logout: Butona t�kland���nda kullan�c�n�n sayfalara eri�imi gider, tekrar giri� yapmas�
beklenmektedir.
----------------------------------------PROJEDE EKS�KL�KLER�M------------------------------------
-> Aksesuarlar� sildikten sonra beni 0 olan bir bo� sayfaya y�nlendirmesi
-> Tak� foto�raf�n� ekledikten sonra d�zg�n �al��mas�na ra�men tak� foto�raflar�
listeleme k�s�m�nda g�z�km�yor. Ekleme ve silme i�lemlerinde veritaban�na da d�zg�n
ekleniyor, proje dosyamdaki wwwroot/images klas�r�nde de normal bir �ekilde eklendi�inde
eklenip silindi�inde de klas�rden siliniyor. Boyuttan kaynakland���n� d���nd���m
bu sorunu ��zemedim.
->
----------------------------------------�ALI�MA S�REC� MANTIK�IM----------------------------
En zorland���m alan tak� g�rseli eklemek oldu�undan dolay� kodlar� ara�t�r�p kendi 
projeme de�i�tirerek entegre etmeye �al��t�m.
-->
" [NotMapped]
  public IFormFile ProfileImage { get; set; }
" kodunu ekleme sebebim, bir HTTP iste�i s�ras�nda g�nderilen dosya bir 
IFormFile nesnesini temsil etmesi etmeliydi. Bu dosyan�n veritaban�nda s�tunu olmad���n�,
saklanmayaca��n� g�stermek i�in [NotMapped] �zelli�ini ekledim.
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
TakiController'da yer alan bu kod par�as� ise;
TakiViewModel s�n�f�nda tan�mlad���m modeller e�er valid ise 'ModelState.IsValid' do�rulamas�ndan
ge�iyor.UploadedFile metodu y�klenen dosyay� i�lenmek ve dosya ad�n�n benzersiz olmas� i�in 
kullan�l�r.TakiViewModel i�indeki "ProfileImage" �zelli�i kulanarak dosyay� al�r ve projemde 'images'
klas�r�ne y�kler. Olu�an dosya 'uniqueFileName' de�i�kenine atan�yor. Atanan dosya ad� 'uniqueFileName'
, 'Taki' s�n�f�na atan�yor ve 'Taki' �zellikleri 'TakiViewModel' i�indeki �zelliklere g�re ayarlan�r.
_db.Add(taki) ile de 'Taki' nesnesini veritaban�na eklemek i�in kulland�m.De�i�ikliklerin hepsinin veritaban�na 
 kaydedilmesini beklyen kod ise 'await _db.SaveChangesAsync()' ifadesidir.'return RedirectToAction(nameof(Index))'
 kodu ise bu eylemlerin 'Index'.chtml'e y�nlendirilir. E�er 'ModelState.Invalid' kontrol�nden ge�emezse, false d�nerse
(TakiViewModel s�n�f�ndan bir tanesinin bile Invalid olmas� yeterli) 'return View()' ifadesi ayn� g�r�nt�y� d�nd�rerek
formu tekrar g�sterir.
-->
TakiController'da bir de bu i�lemleri yaparken Delete metodu i�in de yazd���m kod par�as� �u �ekildedir:
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
"tak�y� veritaban�ndan silmeyi ve ili�kili bir dosyay�(tak� g�rselini)silmeyi sa�lar. '_db.Takiler.FindAsync(id)' ifadesi,
veritaban�nda istenen ID'ye sahip tak�y� bulmak i�in kullan�l�yor.'if (taki != null)' ifadesi, tak�n�n veritaban�nda bulunup 
bulunmad���n� kontrol eder. e�er null de�ilse 'string ExitingFile = Path.Combine(webHostEnvironment.WebRootPath, "images", 
taki.ProfileImagePath);kodu ise, silinecek olan dosyan�n yolunu belirler.'webHostEnvironment.WebRootPath'uygulaman�n k�k 
dizinini temsil ediyor.taki.ProfileImagePath ise tak� nesnesinin profilden gelen resminin dosya ad�n� i�eriyor.
'System.IO.File.Delete(ExitingFile);'ifadesi, se�ilen dosyan�n silinmesini sa�lar.'_db.Takiler.Remove(taki);'ifadesi 
de�i�kenlerin veritaban�na kaydedilmesini sa�lar. 'return await _db.SaveChangesAsync();' kodu ise yap�lan de�i�ikliklerin 
asenkron olarak veritaban�na kaydedilmesini sa�l�yor ve de�i�ikliklerin say�s�n� d�nd�r�yor.

----------------------------------------LOG�N VE ��FRELEME ���N �ZLED���M ADIM ----------------------------
--> Cookie Authentication ile kullan�c�lar�n kimlik do�rulamas� ve oturum y�netimi sa�layabilmek i�in 
kulland�m. Kullan�c� giri� yapt���nda girilen kullan�c� ad� ve �ifre do�rulan�r ve kullan�c�ya bir 
�erez (cookie) verilmi� olur.Bu cookie kullan�c�n�n oturumunun devam edebilmeisni sa�lar ve sonraki
isteklerde kullan�c�y� kimlik do�rulama i�in tan�m�� oluyor.Password Encryption ile de ara�t�rd���mda sadece
veritaban�nda saklamak g�venli gelmedi ve bende kullan�c�lar�n �ifrelerinin g�venli bir �ekilde saklanmas�
i�in bu y�ntemi tercih ettim. 
-->
"  
 [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                //login i�lemleri
                string hashedPassword = DoMD5HashedString(model.Password);

                User user = _db.Users.SingleOrDefault(x => x.UserName.ToLower() == model.UserName.ToLower()
                && x.Password == hashedPassword);

                if (user != null)
                {
                    if (user.Locked)
                    {
                        ModelState.AddModelError(nameof(model.UserName), "Kullan�c� hesab� pasif durumdad�r");
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
                    ModelState.AddModelError("", "Kullan�c� ad� veya �ifre hatal�");

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
Login metodu 'LoginViewModel' tipindeki model nesnesi al�n�r. LoginViewModel,kullan�c� ad� ve �ifre bilgilerini
temsil eder.'ModelState.IsValid' kontrol� ile de, do�rulama ture ise;
'DoMD5HashedString(model.Password)' ifadesi ile de, kullan�c�n�n girdi�i �ifrenin MD5 algoritmas� ile �ifreleyebilmeyi sa�lar
DoMD5HashedString metodu, �ifreyi belirli bir tuzla birle�tirir ve ard�ndan MD5 algoritmas�n� kullanarak �ifreyi hashler.
buradaki en b�y�k ama� g�venlik a���� olu�mas�n� engellmek.'_db.Users.SingleOrDefault' ifadesi, kullan�c� ad� ve �ifreyi
do�rulayabilmek i�in veritaban�nda kullan�c�y� arar.E�er e�le�iyorsa kullan�c�y� d�nd�r�r.Bu ara�t�rmalar�m sonucu:
ClaimsIdentity'nin taleplerle kimlik olu�turmas�,CookieAuthenticationDefaults.AuthenticationScheme'nin kimlik do�rulama
�emas� belirti�ini, HttpContext.SignInAsync'nin de bu metodu olu�turan� kullanarak da kullan�c�y� oturum a�m�� olarak 
belirler. �erezleri kullanarak da kimlik do�rulamas� sa�lar.E�er kullan�c�y� bulamazsa, hata mesaj� 'ModelState.AddModelError'
'a eklenerek d�nd�r�r.'DoMD5HashedString' metodu gelen �ifreyi MD5 algoritmas�n� kullanarak �ifreler.

