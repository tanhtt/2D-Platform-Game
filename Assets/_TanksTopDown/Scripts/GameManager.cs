using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace tank_top_down
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private GameObject player;
        public GameObject Player => player;

        [SerializeField] EnemyMovement enemy;
        [SerializeField] int _score;
        [SerializeField] TextMeshProUGUI scoreText;
        Vector2 oldRandomPos;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(InvokeAfterTime());
        }

        // Update is called once per frame
        void Update()
        {

        }

        void RandomSpawn()
        {
            Vector2 screenSize = Camera.main.ScreenToWorldPoint(new Vector2 (Screen.width, Screen.height));
            Vector2 newPos = Vector2.zero;

            do
            {
                newPos.x = Random.Range(-screenSize.x - 5, screenSize.x + 5);
                newPos.y = Random.Range(-screenSize.y - 5, screenSize.y + 5);
            } while ((newPos.x >= -screenSize.x && newPos.x <= screenSize.x) ||
            (newPos.y >= -screenSize.y && newPos.x <= screenSize.y) ||
                Vector2.Distance(oldRandomPos, newPos) < 2
            );
            oldRandomPos = newPos;
            //EnemyMovement newEnemy =  Instantiate<EnemyMovement>(enemy, newPos, Quaternion.identity);
            GameObject newEnemy = ObjectPooling.Instance.GetObject(enemy.gameObject);
            newEnemy.transform.position = newPos;
            newEnemy.SetActive(true);
        }

        IEnumerator InvokeAfterTime()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(3,7));
                RandomSpawn();
            }
        }

        public void SetScore(int score)
        {
            if(score< 0 || score >= 2)
            {
                return;
            }
            this._score += score;
            this.scoreText.text = "Score: "+ score.ToString();

            PlayerPrefs.SetInt("Score", _score);
        }
    }
}
