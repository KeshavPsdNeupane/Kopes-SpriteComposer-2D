// Part of Kope's SpriteComposer 2D | © 2026 Keshav Prasad Neupane
// Licensed under the MIT License. See LICENSE.md in the project root for details.

public static class EnumExtension
{
    public static string ToIdPart(this System.Enum enumValue)
    {
        return enumValue.ToString().ToLowerInvariant().Replace(" ", "_");
    }
}
