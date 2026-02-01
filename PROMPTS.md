# LLM Kullanım Dokümantasyonu

> Bu dosyayı case boyunca kullandığınız LLM (ChatGPT, Claude, Copilot vb.) etkileşimlerini belgelemek için kullanın.
> Dürüst ve detaylı dokümantasyon beklenmektedir.

## Özet

| Bilgi | Değer |
|-------|-------|
| Toplam prompt sayısı | 6 |
| Kullanılan araçlar | Gemini |
| En çok yardım alınan konular | [Case kurallarına uymak] |
| Tahmini LLM ile kazanılan süre | 3 saat |

---

## Prompt 1: [Case açıklaması ve kuralların özetlenmesi]

**Araç:** [Gemini-Pro]
**Tarih/Saat:** 2026-02-01 13:00

**Prompt:**
```
[Case DOsyaları - burada yazan kurallara göre bana bir tane IInteractable ver bununla birlikte çalışabilecek etkileşim dedektörü ver, script yazım kuralları casede yazdığı gibi olsun ]
```

**Alınan Cevap (Özet):**
```
[Ludu Arts standartlarına ve CSharp_Coding_Conventions.md dokümanına tam uyumlu olarak hazırlanan IInteractable arayüzü ve InteractionDetector sınıfı aşağıdadır.

Bu yapıda, nesnelerle olan etkileşimi yönetmek için Explicit Interface Implementation ve XML Documentation kuralları uygulanmıştır.]
```

**Nasıl Kullandım:**
- [ ] Direkt kullandım (değişiklik yapmadan)
- [x ] Adapte ettim (değişiklikler yaparak)
- [ ] Reddettim (kullanmadım)

**Açıklama:**
> [Projeyi nasıl yapacağımı anlattı.]

**Yapılan Değişiklikler (adapte ettiyseniz):**
> [LLM cevabını nasıl değiştirdiğinizi açıklayın]

---

## Prompt 2: [Case de yapılmasını istenilen objelerin listesi]

**Araç:** [Gemini-Pro]
**Tarih/Saat:** 2026-02-01 14:00

**Prompt:**
```
[bu case projesinde Interaction olmasını istenilen objeleri nasıl etkileşime girilecekleriyle birlikte ver ]
```

**Alınan Cevap (Özet):**
```
[Ludu Arts case dökümanında belirtilen zorunlu gereksinimlere göre, etkileşime girilecek nesneler ve bunların sahip olması gereken Interaction Type (Etkileşim Türü) eşleşmeleri aşağıdadır: Door,Key,Switch]
```

**Nasıl Kullandım:**
- [x ] Direkt kullandım
- [ ] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> [Interaction olacak objelerin listesi ve özellileri]

---

## Prompt 3: [ bu scirptleri incele gözümden kaçan kısmları, kod önerilerini ve lodu artsın benden istediği yazım kurallarına uyup uymadığını kontrol et ]

**Araç:** [Gemini-Pro]
**Tarih/Saat:** 2026-02-01 18:00

**Prompt:**
```
[ bu scirptleri incele gözümden kaçan kısmları, kod önerilerini ve lodu artsın benden istediği yazım kurallarına uyup uymadığını kontrol et  ]
```

**Alınan Cevap (Özet):**
```
[Paylaştığın scriptleri Ludu Arts case dökümanındaki standartlara (C# Conventions, Naming, Prefab Rules) ve istenen özelliklere göre detaylıca inceledim.

Genel olarak yapı sağlam ve mantıklı bir temel üzerine kurulu. Ancak, Ludu Arts'ın "otomatik eleme" sebebi sayabileceği bazı yazım kuralı eksikleri ve geliştirilmesi gereken teknik noktalar mevcut.]
```

**Nasıl Kullandım:**
- [x ] Direkt kullandım
- [ ] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> [Scriptlerin case kurallarına uyup uymaması]

---
## Prompt 4: [Inventory kurulumu]

**Araç:** [Gemini-Pro]
**Tarih/Saat:** 2026-02-01 20:00

**Prompt:**
```
[bu scriptableobjecti kullanrak anahter itemler oluşturuyorum sandıkların içinde. anahtarlara tıklayarak onları inventore eklemek isityorum, daha sonra klavyedeki 1,2,3 tuşlarını kullanarak o itemleri elime alarak kullanacam,bana basit bir inventroy ver ]
```

**Alınan Cevap (Özet):**
```
[Ludu Arts standartlarına ve paylaştığın ItemData yapısına uygun olarak, hem eşyaları saklayacak bir InventoryManager hem de dünyadaki anahtarlar için bir KeyController hazırladım.]
```

**Nasıl Kullandım:**
- [ ] Direkt kullandım
- [ x ] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> [Basit bir Inveentory sistemi yapmasını istedim, uygun hale editledim]

---
## Prompt 5: [Inventory bug]

**Araç:** [Gemini-Pro]
**Tarih/Saat:** 2026-02-01 20:30

**Prompt:**
```
[inventere bir ürün kullandığımda elime geliyorlar, elimdeyken başka item elime almak isteidğimde elimdeki inventorye gidecek, tuşa tıkladığım elime gelecek ]
```

**Alınan Cevap (Özet):**
```
[Ludu Arts standartlarına ve InventoryManager yapına uygun olarak, eşya değiştirme (swapping) mantığını ve elindeki eşyayı envantere geri gönderme mekaniğini içeren güncel yapıyı aşağıda bulabilirsin.]
```

**Nasıl Kullandım:**
- [ ] Direkt kullandım
- [x ] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> [Kullanım için daha uyugun olacak hale gitirmesini isteidm]

---
## Prompt 6: [Scirptlerin kurallara göre uyup uymadığını kontrol edilmesi]

**Araç:** [Gemini-Pro]
**Tarih/Saat:** 2026-02-01 21:00

**Prompt:**
```
[bu scirptleri de incele şuan sistemin son halinde olduğuımu düşünüyorum. case yazıları ve kurallarıyla kıyasla  ]
```

**Alınan Cevap (Özet):**
```
[Sistemini genel olarak incelediğimde, Ludu Arts case dökümanındaki "Must Have" gereksinimlerinin neredeyse tamamını karşıladığını ve mimari olarak doğru bir yolda olduğunu görüyorum. Ancak, Ludu Arts'ın CSharp_Coding_Conventions.md ve Naming_Convention_Kilavuzu.md dökümanlarında yer alan "kritik" kurallarda bazı eksiklikler ve "otomatik eleme" riski taşıyan noktalar var.]
```

**Nasıl Kullandım:**
- [x ] Direkt kullandım
- [ ] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> [Case kurallarını kontrol ettim]

---
## Genel Değerlendirme

### LLM'in En Çok Yardımcı Olduğu Alanlar
1. [Kuralların listesi]
2. [Yapılacaklar listesi]
3. [Inventory]

### LLM Kullanımı Hakkında Düşüncelerim
> [Projeyi yetiştirmeme ve yapacağımı kontrol etmeme yardımcı oldu]

---

## Notlar

- Her önemli LLM etkileşimini kaydedin
- Copy-paste değil, anlayarak kullandığınızı gösterin
- LLM'in hatalı cevap verdiği durumları da belirtin
- Dürüst olun - LLM kullanımı teşvik edilmektedir

---

*Bu şablon Ludu Arts Unity Intern Case için hazırlanmıştır.*
