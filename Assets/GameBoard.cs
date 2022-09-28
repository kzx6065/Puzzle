using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBoard : MonoBehaviour
{
    public static GameBoard instance;
    private void Awake() => instance = this;
    private void OnDestroy() => instance = null;

    public int score;
    public int MaxCount = 12;
    public Text scoreText;
    public GameObject stageClearUigo;
    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
        if (score == MaxCount)
        {
            stageClearUigo.SetActive(true);
        }
    }

    [SerializeField] //private 속성을 보이게 해줌.
    private Sprite[] sprites;
    public Image[] images;

    [ContextMenu ("이미지 배치")]

    void SetImage()
    {
        print("SetImage");
        for(int i = 0; i < sprites.Length; i++)
        {
            images[i].sprite = resultSprite[i]; //sprites[i];
            images[i].name = resultSprite[i].name;
        }
    }

    public Texture2D targetImage;
    public int xCount = 3;
    public int yCount = 4;
    public List<Sprite> resultSprite;
    public int width;
    public int height;

    public Transform backPanel;
    public Transform movePanel;
    public RuntimeAnimatorController controller;

    [ContextMenu("이미지 생성")]
    void CreateSprite()
    {
        //sprites 생성한 이미지 할당.
        //resultSprite = Sprite.Create(targetImage, rect, new Vector2(0.5f, 0.5f));

        resultSprite.Clear();
        width = targetImage.width / xCount;
        height = targetImage.height / yCount;

        for (int y = 0; y < yCount; y++)
        {
            for (int x = 0; x < xCount; x++)
            {
                Rect rect = new Rect();
                rect.x = x * width;
                rect.y = y * height;
                rect.width = width;
                rect.height = height;

                var sprite = Sprite.Create(targetImage, rect, new Vector2(0.5f, 0.5f));
                sprite.name = $"X:{x}, Y:{y}"; 
                resultSprite.Add(sprite);
            }
        }

        //image게임 오브젝트 생성.
        DestroyChild(backPanel);
        DestroyChild(movePanel);

        //이미지 게임 오브젝트 생성.
        CreateImage(backPanel, resultSprite, typeof(SnapPiece));
        CreateImage(movePanel, resultSprite, typeof(Piece));

        //backPanel SnapPiece.
        //movePanel Piece

        backPanel.GetComponent<GridLayoutGroup>().constraintCount = xCount;
        movePanel.GetComponent<RandomSetter>().SetRandomPosition();

        var pieces = movePanel.GetComponentsInChildren<Piece>();
        foreach (var item in pieces)
        {
            var animator = item.gameObject.AddComponent<Animator>();
            if(animator != null) animator.runtimeAnimatorController = controller;
            item.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        }
    }

        private void CreateImage(Transform parentPanel, List<Sprite> resultSprite, Type type)
    {
        int index = 0;
        for (int y = 0; y < yCount; y++)
        {
            for (int x = 0; x < xCount; x++)
            {
                GameObject newGo = new GameObject();
                newGo.name = $"X:{x}, Y:{y}";
                newGo.transform.SetParent(parentPanel);
                newGo.transform.localScale = new Vector3(1, 1, 1);

                Image Imgae = newGo.AddComponent<Image>();
                newGo.AddComponent(type);
                Imgae.sprite = resultSprite[index++];
            }
        }
    }

    private void DestroyChild(Transform parentTr)
    {
        var childs = parentTr.GetComponentsInChildren<Transform>();
        foreach (var item in childs)
        {
            if (item == parentTr) continue;

            if(Application.isPlaying)
                Destroy(item.gameObject);
            else
                DestroyImmediate(item.gameObject, true);
        }
    }
}
