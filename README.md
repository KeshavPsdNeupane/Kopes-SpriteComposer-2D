## ⚖️ License & Attribution
Licensed under the **MIT License**. This project is open and free to use for commercial and personal projects.



# Kope's SpriteComposer 2D

[**© 2026 Keshav Prasad Neupane ("Kope")** **License:**](./LICENSE.md) [MIT License](https://opensource.org/licenses/MIT)

---


## 🌟 The Spirit of the Project
This project was created for the purpose of learning and creating a modular system for Unity 2D. It is made open-source to respect the **LPC (Liberated Pixel Cup)** spirit and freeness due to use of their asset during creation. It is shared to support the game development community and honor the philosophy of open collaboration.

## 📖 Overview
**Kope's SpriteComposer 2D** is a comprehensive framework for Unity designed to handle modular character assembly. It allows developers to build characters from independent body parts and equipment while keeping animations perfectly synchronized through a data-driven, performant approach.


## 🚀 Key Features

### High-Performance Runtime
* **Intelligent Resolution:** Resolves correct sprite libraries based on Race, Gender, and Variant using $O(1)$ HashSet lookups.
* **Dynamic Equipment:** Real-time equipping/unequipping with automatic animation synchronization.
* **Layered Fallbacks:** Automatically reverts to base body libraries when equipment is cleared.
* **Deterministic Sync:** Ensures all independent body regions (head, torso, legs, etc.) stay visually in sync during complex animation states.

### Professional Editor Suite
* **Grid Auto Slicer:** Mass-slices spritesheets into named animation frames based on row templates.
* **Library Populator:** Automatically generates `SpriteLibraryAssets` from templates, preserving complex structures instantly.
* **Animation Snap Tool:** Instantly aligns modular parts to specific frames for testing. **Supports Unity Animator Recording Mode** for rapid keyframing.

---

## 🛠 Technical Design Philosophy
* **Enum-Based Pipeline:** Uses strictly defined ID gaps (e.g., 0-499, 500-999) in enums to allow massive expansion without breaking existing data.
* **Fail-Fast Validation:** Includes `OnValidate` logic to catch invalid library setups before they reach a game build.
* **Modularity:** Uses Generics (`TPart`) to remain agnostic to your specific body parts—customize the enums and the framework adapts.

---

## 📋 Usage Flow

### 1. Asset Preparation
1. Prepare your spritesheets (LPC-compatible or custom).
2. Define **Row Naming Data** assets to match your sheet layout.
   * *See `animation_row_name_template_asset` for an example.*
3. Slice and auto-name frames using the **Grid Auto Slicer** (`Tools > Grid Auto Slicer`).

### 2. Sprite Library Generation
1. Create a "Dummy" `SpriteLibraryAsset` to act as your animation template.
   * *A dummy asset `base_dummy_animation_asset` (Idle, Walk, Thrust, Spell, Swing) is included.*
2. Use the **Populator** (`Tools > Populate Library From Dummy`) to map your sliced textures to the template.
3. Convert the output to `.spriteLib` using the Unity Asset Upgrader.

### 3. ScriptableObject (SO) Configuration
To make the libraries usable by the resolver, you must wrap them in ScriptableObjects:
1. Create a Body or Equipment asset via: `Create > Animation > BodyRegionAsset or EquipmentAsset`.
2. Fill in the **Variant Name**, **Gender**, **Race Whitelist**, **Body Part** and **Color**type.
3. Assign your generated `.spriteLib` to this SO.
4. **Naming Convention:** It is highly recommended to name these assets using the format `gender_part_variant_color` (e.g., `male_torso_plate_iron`).
   * *Note: While not strictly required for logic yet, this format is optimized for future Addressables integration.*

### 4. Assembly & Testing
1. Attach the `StaticAnimationLibraryResolver` (or a custom resolver) to your character prefab.
2. Assign your configured **SO Assets** (from Step 3) to the resolver.
3. Use the **Snap Tool** to preview animations. Toggle **Record Mode** in the Unity Animator to save these snaps as keyframes automatically.

---

## ⑄ Optimization: Better Y-Sorting
To prevent modular parts from flickering or sorting incorrectly:

1. **Sorting Layers:** Create a layer named `Actor` or `Entity`.
2. **Project Settings:** In *Graphics > Transparency Sort Mode*, set to `Custom Axis` (**X:0, Y:1, Z:0**).
3. **Pivots:** Ensure Sprite Renderers use `Pivot` for sorting. (The included "Set to Pivot" script automates this).
4. **Canvas Grouping:** Add a `Canvas Group` to the parent GameObject of your modular parts. This forces Unity to treat the entire character as a single unit for sorting purposes.

---

## ⚖️ License & Attribution
Licensed under the **MIT License**.


**Attribution:** While not legally required by MIT for the final product, I kindly request credit in your "About" or "Credits" section:
> *Contains Kope's SpriteComposer 2D by Keshav Prasad Neupane*

**LPC Note:** Any LPC assets included are subject to their original licenses (GPL/CC BY-SA). This license applies only to the C# source code and framework logic.
