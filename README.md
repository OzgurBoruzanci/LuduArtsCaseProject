# Interaction System - [Adýnýz Soyadýnýz]

> Ludu Arts Unity Developer Intern Case

## Proje Bilgileri

| Bilgi | Deðer |
|-------|-------|
| Unity Versiyonu | 20XX.X.XXf1 |
| Render Pipeline | Built-in / URP / HDRP |
| Case Süresi | X saat |
| Tamamlanma Oraný | %XX |

---

## Kurulum

1. Repository'yi klonlayýn:
```bash
git clone https://github.com/[username]/[repo-name].git
```

2. Unity Hub'da projeyi açýn
3. `Assets/[ProjectName]/Scenes/TestScene.unity` sahnesini açýn
4. Play tuþuna basýn

---

## Nasýl Test Edilir

### Kontroller

| Tuþ | Aksiyon |
|-----|---------|
| WASD | Hareket |
| Mouse | Bakýþ yönü |
| E | Etkileþim |
| [Diðer] | [Açýklama] |

### Test Senaryolarý

1. **Door Test:**
   - Kapýya yaklaþýn, "Press E to Open" mesajýný görün
   - E'ye basýn, kapý açýlsýn
   - Tekrar basýn, kapý kapansýn

2. **Key + Locked Door Test:**
   - Kilitli kapýya yaklaþýn, "Locked - Key Required" mesajýný görün
   - Anahtarý bulun ve toplayýn
   - Kilitli kapýya geri dönün, þimdi açýlabilir olmalý

3. **Switch Test:**
   - Switch'e yaklaþýn ve aktive edin
   - Baðlý nesnenin (kapý/ýþýk vb.) tetiklendiðini görün

4. **Chest Test:**
   - Sandýða yaklaþýn
   - E'ye basýlý tutun, progress bar dolsun
   - Sandýk açýlsýn ve içindeki item alýnsýn

---

## Mimari Kararlar

### Interaction System Yapýsý

```
[Mimari diyagram veya açýklama]
```

**Neden bu yapýyý seçtim:**
> [Açýklama]

**Alternatifler:**
> [Düþündüðünüz diðer yaklaþýmlar ve neden seçmediniz]

**Trade-off'lar:**
> [Bu yaklaþýmýn avantaj ve dezavantajlarý]

### Kullanýlan Design Patterns

| Pattern | Kullaným Yeri | Neden |
|---------|---------------|-------|
| [Observer] | [Event system] | [Açýklama] |
| [State] | [Door states] | [Açýklama] |
| [vb.] | | |

---

## Ludu Arts Standartlarýna Uyum

### C# Coding Conventions

| Kural | Uygulandý | Notlar |
|-------|-----------|--------|
| m_ prefix (private fields) | [x] / [ ] | |
| s_ prefix (private static) | [x] / [ ] | |
| k_ prefix (private const) | [x] / [ ] | |
| Region kullanýmý | [x] / [ ] | |
| Region sýrasý doðru | [x] / [ ] | |
| XML documentation | [x] / [ ] | |
| Silent bypass yok | [x] / [ ] | |
| Explicit interface impl. | [x] / [ ] | |

### Naming Convention

| Kural | Uygulandý | Örnekler |
|-------|-----------|----------|
| P_ prefix (Prefab) | [x] / [ ] | P_Door, P_Chest |
| M_ prefix (Material) | [x] / [ ] | M_Door_Wood |
| T_ prefix (Texture) | [x] / [ ] | |
| SO isimlendirme | [x] / [ ] | |

### Prefab Kurallarý

| Kural | Uygulandý | Notlar |
|-------|-----------|--------|
| Transform (0,0,0) | [x] / [ ] | |
| Pivot bottom-center | [x] / [ ] | |
| Collider tercihi | [x] / [ ] | Box > Capsule > Mesh |
| Hierarchy yapýsý | [x] / [ ] | |

### Zorlandýðým Noktalar
> [Standartlarý uygularken zorlandýðýnýz yerler]

---

## Tamamlanan Özellikler

### Zorunlu (Must Have)

- [x] / [ ] Core Interaction System
  - [x] / [ ] IInteractable interface
  - [x] / [ ] InteractionDetector
  - [x] / [ ] Range kontrolü

- [x] / [ ] Interaction Types
  - [x] / [ ] Instant
  - [x] / [ ] Hold
  - [x] / [ ] Toggle

- [x] / [ ] Interactable Objects
  - [x] / [ ] Door (locked/unlocked)
  - [x] / [ ] Key Pickup
  - [x] / [ ] Switch/Lever
  - [x] / [ ] Chest/Container

- [x] / [ ] UI Feedback
  - [x] / [ ] Interaction prompt
  - [x] / [ ] Dynamic text
  - [x] / [ ] Hold progress bar
  - [x] / [ ] Cannot interact feedback

- [x] / [ ] Simple Inventory
  - [x] / [ ] Key toplama
  - [x] / [ ] UI listesi

### Bonus (Nice to Have)

- [ ] Animation entegrasyonu
- [ ] Sound effects
- [ ] Multiple keys / color-coded
- [ ] Interaction highlight
- [ ] Save/Load states
- [ ] Chained interactions

---

## Bilinen Limitasyonlar

### Tamamlanamayan Özellikler
1. [Özellik] - [Neden tamamlanamadý]
2. [Özellik] - [Neden]

### Bilinen Bug'lar
1. [Bug açýklamasý] - [Reproduce adýmlarý]
2. [Bug]

### Ýyileþtirme Önerileri
1. [Öneri] - [Nasýl daha iyi olabilirdi]
2. [Öneri]

---

## Ekstra Özellikler

Zorunlu gereksinimlerin dýþýnda eklediklerim:

1. **[Özellik Adý]**
   - Açýklama: [Ne yapýyor]
   - Neden ekledim: [Motivasyon]

2. **[Özellik Adý]**
   - ...

---

## Dosya Yapýsý

```
Assets/
??? [ProjectName]/
?   ??? Scripts/
?   ?   ??? Runtime/
?   ?   ?   ??? Core/
?   ?   ?   ?   ??? IInteractable.cs
?   ?   ?   ?   ??? ...
?   ?   ?   ??? Interactables/
?   ?   ?   ?   ??? Door.cs
?   ?   ?   ?   ??? ...
?   ?   ?   ??? Player/
?   ?   ?   ?   ??? ...
?   ?   ?   ??? UI/
?   ?   ?       ??? ...
?   ?   ??? Editor/
?   ??? ScriptableObjects/
?   ??? Prefabs/
?   ??? Materials/
?   ??? Scenes/
?       ??? TestScene.unity
??? Docs/
?   ??? CSharp_Coding_Conventions.md
?   ??? Naming_Convention_Kilavuzu.md
?   ??? Prefab_Asset_Kurallari.md
??? README.md
??? PROMPTS.md
??? .gitignore
```

---

## Ýletiþim

| Bilgi | Deðer |
|-------|-------|
| Ad Soyad | [Adýnýz] |
| E-posta | [email@example.com] |
| LinkedIn | [profil linki] |
| GitHub | [github.com/username] |

---

*Bu proje Ludu Arts Unity Developer Intern Case için hazýrlanmýþtýr.*


