# Kope's SpriteComposer 2D

[**© 2026 Keshav Prasad Neupane ("Kope")** **License:**](./LICENSE.md) [MIT License](https://opensource.org/licenses/MIT)

---

## 🌟 The Spirit of the Project
This project was created for the purpose of learning and creating a modular system for Unity 2D. It is made open-source to respect the **LPC (Liberated Pixel Cup)** spirit and freeness. It is shared to support the game development community and honor the philosophy of open collaboration.

## 📖 Overview
**Kope's SpriteComposer 2D** is a comprehensive framework for Unity designed to handle modular character assembly. It allows developers to build characters from independent body parts and equipment while keeping animations perfectly synchronized through a data-driven, performant approach.

---

## 🚀 Key Features

### High-Performance Runtime
* **Intelligent Resolution:** Resolves correct sprite libraries based on Race, Gender, and Variant using $O(1)$ HashSet lookups.
* **Dynamic Equipment:** Real-time equipping/unequipping with automatic animation synchronization.
* **Layered Fallbacks:** Automatically reverts to base body libraries when equipment is cleared.
* **Deterministic Sync:** Keeps all independent body regions visually in sync across complex animation states.

### Professional Editor Suite
* **Grid Auto Slicer:** Mass-slices spritesheets into properly named animation frames based on custom row-naming templates.
* **Library Populator:** Generates `SpriteLibraryAssets` from templates, preserving complex animation structures instantly.
* **Animation Snap Tool:** Instantly aligns all modular parts to specific animation frames for rapid visual testing. **Supports Unity Animator Recording Mode** for rapid keyframing.

---

## 🛠 Technical Design Philosophy
* **Enum-Based Data Pipeline:** Uses strictly defined ID gaps (0-499, 500-999) in enums to allow massive sub-race and item expansion without breaking existing data.
* **Fail-Fast Validation:** Extensive `OnValidate` logic ensures designers catch invalid library setups before they ever reach a game build.
* **Modularity:** Uses Generics (`TPart`) to remain agnostic to your specific body parts—customize the enums and the framework adapts.

---

## 📋 Usage Flow

### 1. Asset Preparation
1.  Prepare your spritesheets (LPC-compatible or custom).
2.  Define your **Row Naming Data** assets to match your spritesheet layout. 
    * *See the provided `animation_row_name_template_asset` for a baseline example.*
3.  Slice and auto-name frames using the **Grid Auto Slicer** (`Tools > Grid Auto Slicer`).

### 2. Library Generation
1.  Define a "Dummy" `SpriteLibraryAsset` to act as your animation template.
    * *A dummy asset `base_dummy_animation_asset` containing Idle, Walk, Thrust, Spell, and Swing is included as an example.*
2.  Use the **Populator** (`Tools > Populate Library From Dummy`) to map your sliced textures to the template.
3.  Convert the output to `.spriteLib` using the Unity Asset Upgrader.

### 3. Assembly & Testing
1.  Attach the `StaticAnimationLibraryResolver` (or your custom resolver) to your character prefab.
2.  Assign your generated libraries.
3.  Use the **Snap Tool** to preview animations. You can also use this tool while the **Unity Animator is in Record Mode** to record keyframes directly.

---

## ⑄ Optimization: Better Y-Sorting
To ensure your modular parts don't "flicker" or sort incorrectly against the environment, follow these steps:

1.  **Sorting Layers:** Create a dedicated Sorting Layer named `Actor`, `Entity`, or similar.
2.  **Project Settings:** Go to *Project Settings > Graphics*. Under **Transparency Sort Mode**, set it to `Custom Axis` and set the **Transparency Sort Axis** to:
    * **X: 0, Y: 1, Z: 0**
3.  **Sprite Renderers:** Ensure all modular Sprite Renderers have their **Sorting Event/Location** set to `Pivot`. 
    * *Note: The included "Set to Pivot" script automates this process.*
4.  **Canvas Grouping:** Add a `Canvas Group` component to the most direct ancestor of all GameObjects using `CustomSpriteLibraryDefinition`, or any parent that encapsulates all of your modular sprite renderers. This helps Unity treat the modular parts as a single sortable unit.

---

## ⚖️ License & Attribution
Licensed under the **MIT License**. This project is open and free to use for commercial and personal projects.

**Attribution:** While not legally required by MIT for the final product, I kindly request credit in your "About" or "Credits" section:
> *Contains Kope's SpriteComposer 2D by Keshav Prasad Neupane*

**LPC Note:** Any LPC assets included are subject to their original licenses (GPL/CC BY-SA). This license applies only to the C# source code and framework logic.