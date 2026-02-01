# Interaction System - Özgür Boruzancı
> Ludu Arts Unity Developer Intern Case

## Proje Bilgileri

| Bilgi | Değer |
|-------|-------|
| Unity Versiyonu | 6000.0.53f1 |
| Render Pipeline | Built-in / URP |
| Case Süresi | 8 saat |
| Tamamlanma Oranı | %100 |

---

## Kurulum

1. Repository'yi klonlayın:
```bash
git clone https://github.com/OzgurBoruzanci/LuduArtsCaseProject
```

2. Unity Hub'da projeyi açın
3. `Assets/[LuduArtsCaseProject]/Scenes/TestScene.unity` sahnesini açın
4. Play tuşuna basın

---

## Nasıl Test Edilir

### Kontroller

| Tuş | Aksiyon |
|-----|---------|
| WASD | Hareket |
| Mouse | Bakış yönü |
| E | Etkileşim |
| [Diğer] | [Açıklama] |

### Test Senaryoları

1. Door & Lock Test:

    - Kapıya yaklaşın, "Press E to Open" yazısını görünce açın.
    - Kilitli kapıya gidin. "Locked - Key A Requires" uyarısını görün.
    - Yanlış bir anahtarla denerseniz "Wrong Key" mesajını test edin.
     -Doğru anahtarı bulup açın (Anahtarın uçarak kilide gitme animasyonunu izleyin).

2. Inventory & Swapping Test:

   - Yerdeki anahtarları toplayın.
   -1, 2, 3 tuşları ile anahtarı elinize alın (Equip).
   - Elinizde bir eşya varken, envanterdeki başka bir eşyanın tuşuna basarak eşya takaslama (swap) özelliğini test edin.

3. Chest (Hold Interaction) Test:

    - Sandığa yaklaşın. "Hold E to Open" yazısını görün.
    - E tuşuna basılı tutun. Yuvarlak progress bar'ın dolduğunu izleyin.
    - 3 saniye sonunda sandık açılacak ve içinden rastgele eşyalar (Loot) fırlayacaktır.

4. witch & Events:

    - Işık anahtarına (Switch) tıklayarak ortam ışığını açıp kapatın.
    - DOTween ile yapılan yumuşak geçişleri gözlemleyin.

---

## Mimari Kararlar

Interaction System Yapısı

Sistem, Interface-based (Arayüz tabanlı) bir yapı üzerine kurulmuştur.

    IInteractable: Tüm etkileşimli nesneler (Kapı, Sandık, Anahtar) bu arayüzü uygular.

    InteractionDetector: Oyuncu tarafındaki bu script, sadece IInteractable arayüzünü arar. Karşısındaki nesnenin ne olduğunu (Kapı mı, Sandık mı?) bilmesine gerek yoktur. Bu sayede sistem Loose Coupling (Gevşek Bağlılık) prensibine uyar.

Neden bu yapıyı seçtim:

    SOLID prensiplerine (özellikle Open/Closed Principle) uygun olması için. Yeni bir etkileşimli nesne eklemek istediğimde Player koduna dokunmama gerek kalmıyor; sadece yeni objeye interface'i implemente etmem yetiyor.

### Kullanılan Design Patterns

| Pattern | Kullanım Yeri | Neden |
|---------|---------------|-------|
| [Singleton Pattern] | [InventoryManager, InteractionDetector] | [Global erişim ve tekil yönetim gerektiren sistemler için (UI mesajları, envanter kontrolü).] |
| [DOTween] | [Kapı, Sandık, Anahtar Hareketi] | [Unity'nin standart animasyon sistemi yerine, kod tabanlı ve daha performanslı olduğu için tercih edildi.] |
| [Raycast System] | [InteractionDetector] | [Merkezden çıkan ışın ile nesne tespiti (Player ve Trigger layer'ları ignore edilerek optimize edildi).] |
| [vb.] | | |

---

## Ludu Arts Standartlarına Uyum

### C# Coding Conventions

| Kural | Uygulandı | Notlar |
|-------|-----------|--------|
| m_ prefix (private fields) | [x] / [Tüm private değişkenlerde uygulandı. ] | |
| s_ prefix (private static) | [x] / [ ] | |
| k_ prefix (private const) | [x] / [ Sabit değerlerde uygulandı.] | |
| Region kullanımı | [x] / [ Fields, Unity Methods, Methods şeklinde ayrıldı.] | |
| Region sırası doğru | [x] / [ ] | |
| XML documentation | [x] / [Public API ve Interface metodlarına eklendi. ] | |
| Silent bypass yok | [x] / [ Null check'ler yapıldı, gerekli yerlere hata logları eklendi.] | |
| Explicit interface impl. | [x] / [ ] | |

### Naming Convention

| Kural | Uygulandı | Örnekler |
|-------|-----------|----------|
| P_ prefix (Prefab) | [x] / [ Prefablar: P_Door, P_Chest, P_Player formatında isimlendirildi.] | P_Door, P_Chest |
| M_ prefix (Material) | [x] / [Materiallar: M_Black, M_Gray formatında isimlendirildi. ] | M_Door_Wood |
| T_ prefix (Texture) | [x] / [ ] | |
| SO isimlendirme | [x] / [ ] | |

### Prefab Kuralları

| Kural | Uygulandı | Notlar |
|-------|-----------|--------|
| Transform (0,0,0) | [x] / [Transform: Tüm prefabların root değerleri (0,0,0) olarak ayarlandı ] | |
| Pivot bottom-center | [x] / [Pivot: Kapı ve karakter pivotları standartlara (Bottom/Hinge) uygun ayarlandı. ] | |
| Collider tercihi | [x] / [ ] | Box > Capsule > Mesh |
| Hierarchy yapısı | [x] / [ ] | |

---

## Tamamlanan Özellikler

### Zorunlu (Must Have)

- [x] / [ x] Core Interaction System
  - [x] / [x ] IInteractable interface
  - [x] / [x ] InteractionDetector
  - [x] / [x ] Range kontrolü

- [x] / [x ] Interaction Types
  - [x] / [ ] Instant
  - [x] / [ ] Hold
  - [x] / [ ] Toggle

- [x] / [x ] Interactable Objects
  - [x] / [x ] Door (locked/unlocked)
  - [x] / [x ] Key Pickup
  - [x] / [ x] Switch/Lever
  - [x] / [ x] Chest/Container

- [x] / [x ] UI Feedback
  - [x] / [ x] Interaction prompt
  - [x] / [ x] Dynamic text
  - [x] / [x ] Hold progress bar
  - [x] / [ ] Cannot interact feedback

- [x] / [x ] Simple Inventory
  - [x] / [x ] Key toplama
  - [x] / [x ] UI listesi

### Bonus (Nice to Have)

- [x ] Animation entegrasyonu
- [ ] Sound effects
- [x ] Multiple keys / color-coded
- [ ] Interaction highlight
- [ ] Save/Load states
- [ ] Chained interactions

---

## Bilinen Limitasyonlar

### Tamamlanamayan Özellikler
1. [Ses Efektleri] - [Proje kapsamında ses dosyaları entegre edilmemiştir]
2. [Save/Load] - [Oyun durumu kaydedilmemektedir.]

---

## Dosya Yapısı

```
Assets/
└── LuduArts_Case/
    ├── Scripts/
    │   ├── Runtime/
    │   │   ├── Core/           # IInteractable, InteractablePart
    │   │   ├── Interactables/  # Door, Chest, Switch, PickupItem
    │   │   ├── Player/         # InteractionDetector, InventoryManager, PlayerController
    │   │   └── ScriptableObjects/ # ItemData
    ├── Prefabs/                # P_Door, P_Chest, P_Player...
    ├── Scenes/                 # TestScene
    └── Docs/                   # Standart dokümanlar
└── README.md
└── PROMPTS.md
└── .gitignore
```

---

## İletişim

| Bilgi | Değer |
|-------|-------|
| Ad Soyad | [Özgür Boruzancı] |
| E-posta | [ozgurboruzanc@gmail.com] |
| LinkedIn | [[profil linki](https://www.linkedin.com/in/%C3%B6zg%C3%BCr-boruzanc%C4%B1-188005226/)] |
| GitHub | [[https://github.com/OzgurBoruzanci] |

---

*Bu proje Ludu Arts Unity Developer Intern Case için hazırlanmıştır.*


