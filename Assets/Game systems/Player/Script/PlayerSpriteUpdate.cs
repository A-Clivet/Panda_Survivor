using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteUpdate : MonoBehaviour
{
    public List<Sprite> sprites;

    public void Test(float test){}
    
    private PolygonCollider2D polygonCollider;
    
    private bool index;

    private void OnEnable()
    {
        SetColliderShape();
        print("enabled");
    }

    // Liste pour stocker les formes des deux sprites
    private readonly List<List<Vector2>> physicsShapes = new();

    private void Start()
    {
        print("start");
        polygonCollider = GetComponent<PolygonCollider2D>();
        // Récupération des composants
        foreach (Sprite sprite in sprites)
        {
            StoreSpriteShape(sprite);
        }

        // Appliquer la première forme au collider
        SetColliderShape();
    }

    private void StoreSpriteShape(Sprite sprite)
    {
        if (sprite is null) return;
        
        var shapePath = new List<Vector2>();
        sprite.GetPhysicsShape(0, shapePath);
        physicsShapes.Add(new List<Vector2>(shapePath));
    }
    
    public void SetColliderShape()
    {
        index = !index;
        polygonCollider.SetPath(0, physicsShapes[index ? 1 : 0]);
    }
}