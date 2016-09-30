using UnityEngine;
using System.Collections;

public class DestructableTerrain : MonoBehaviour {

    [SerializeField]
    private SpriteRenderer spriteRend;
    [SerializeField]
    private Texture2D ground;
    private Color alpha = new Color(0f, 0f, 0f, 0f);
    private float worldWidth, worldHeight;
    private int widthPixel, heightPixel;
    private PolygonCollider2D polyGonCol;
    

    void Awake()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        polyGonCol = GetComponent<PolygonCollider2D>();
        ground = (Texture2D)Resources.Load("ground2(Clone)");
        Texture2D groundClone = (Texture2D)GameObject.Instantiate(ground);

        spriteRend.sprite = Sprite.Create(ground,new Rect(0f, 0f, ground.width, ground.height),new Vector2(0.5f, 0.5f), 100f);
        SetSprite();
    }
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GroundUpdate(CircleCollider2D circleCol)
    {
        V2int c = World2Pixel(circleCol.bounds.center.x, circleCol.bounds.center.y);
        int r = Mathf.RoundToInt(circleCol.bounds.size.x * widthPixel / worldWidth);

        int x, y, px, nx, py, ny, d;

        for (x = 0; x <= r; x++)
        {
            d = (int)Mathf.RoundToInt(Mathf.Sqrt(r * r - x * x));

            for (y = 0; y <= d; y++)
            {
                px = c.x + x;
                nx = c.x - x;
                py = c.y + y;
                ny = c.y - y;

                spriteRend.sprite.texture.SetPixel(px, py, alpha);
                spriteRend.sprite.texture.SetPixel(nx, py, alpha);
                spriteRend.sprite.texture.SetPixel(px, ny, alpha);
                spriteRend.sprite.texture.SetPixel(nx, ny, alpha);
            }
        }
        spriteRend.sprite.texture.Apply();
        Destroy(GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>();

    }
    private V2int World2Pixel(float x, float y)
    {
        V2int v = new V2int();

        float dx = x - transform.position.x;
        v.x = Mathf.RoundToInt(0.5f * widthPixel + dx * widthPixel / worldWidth);

        float dy = y - transform.position.y;
        v.y = Mathf.RoundToInt(0.5f * heightPixel + dy * heightPixel / worldWidth);

        return v;
    }

    void SetSprite()
    {
        worldWidth = spriteRend.bounds.size.x;
        worldHeight = spriteRend.bounds.size.y;
        widthPixel = spriteRend.sprite.texture.width;
        heightPixel = spriteRend.sprite.texture.height;
    }
}
