using Microsoft.AspNetCore.Mvc.Rendering;

namespace ContactPageProject.Models.SelectLists
{
    public class SelectLists :ISelectLists
    {
        public List<string> DepartmentList { get; } = new List<string> {

        "Aktüerya ve Risk Yönetimi",
        "Anatomi",
        "Arkeoloji",
        "Atık Yönetimi",
        "Beden Eğitimi ve Spor",
        "Bilgisayar Mühendisliği",
        "Biyoinformatik",
        "Biyomedikal Mühendisliği",
        "Bölge Çalışmaları",
        "Çevre Mühendisliği",
        "Çocuk Gelişimi ve Eğitimi",
        "Coğrafya",
        "Doğal Kaynakların Sürdürülebilir Planlanması ve Yönetimi",
        "Ebelik",
        "Eğitim Bilimleri",
        "Elektrik-Elektronik Mühendisliği",
        "Endüstri Mühendisliği",
        "Endüstriyel Tasarım Mühendisliği",
        "Enerji Sistemleri Mühendisliği",
        "Etik Değerler",
        "Felsefe ve Din Bilimleri",
        "Finans ve Bankacılık - Finans ve Katılım Bankacılığı",
        "Fizik",
        "Fizyoterapi ve Rehabilitasyon",
        "Gastronomi ve Mutfak Sanatları",
        "Gıda Toksikolojisi",
        "Girişimcilik",
        "Halk Sağlığı",
        "Hareket ve Antrenman Bilimleri",
        "Hemşirelik Bilimi",
        "İktisat",
        "İletişim",
        "İmalat Mühendisliği",
        "İnşaat Mühendisliği",
        "İngiliz Dili ve Edebiyatı",
        "İşletme",
        "Kamu Yönetimi",
        "Kimya",
        "Kültürel Miras ve Miras Alan Yönetimi",
        "Makine Mühendisliği",
        "Matematik",
        "Mekatronik Mühendisliği",
        "Metalürji ve Malzeme Mühendisliği",
        "Mimarlık",
        "Orman Endüstri Mühendisliği",
        "Orman Mühendisliği",
        "Resim",
        "Ruh Sağlığı ve Hastalıkları Hemşireliği",
        "Sağlık Turizmi",
        "Sanat Tarihi",
        "Sosyal Hizmet",
        "Sosyoloji",
        "Tarih",
        "Temel İslam Bilimleri",
        "Tıbbi Biyokimya",
        "Tıbbi Mikrobiyoloji",
        "Turizm İşletmeciliği",
        "Türk Dili ve Edebiyatı",
        "Uluslararası İlişkiler",
        "Uluslararası Politik Ekonomi",
        "Yapay Zeka Mühendisliği",
        "Yeni Medya ve İletişim-Medya ve İletişim Çalışmaları",
        "Yönetim Bilişim Sistemleri"
        };

        public List<string> relevantUnitList { get; } = new List<string>
        {
            "Fen Bilimleri Öğrenci İşleri",
            "Sağlık Bilimleri Öğrenci İşleri",
            "Sosyal Bilimleri Öğrenci İşleri",
            "Mezuniyet ve Diploma",
            "Yönetim Kurulu",
            "Yazı İşleri",
            "Mali İşler",
            "Enstitü Sekreteri",
            "Diğer Konular"
        };
 
        public SelectList GetDepartmentSelectList()
        {
            return new SelectList(DepartmentList);
        }

        public SelectList RelevantUnitList()
        {
            return new SelectList(relevantUnitList);
        }
    }
}

