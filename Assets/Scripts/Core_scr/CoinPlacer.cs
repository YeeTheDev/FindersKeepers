using UnityEngine;

namespace FK.Core
{
    public class CoinPlacer : MonoBehaviour
    {
        [SerializeField] Transform[] placePoints;
        [SerializeField] Transform[] coins;

        public void PlaceCoins()
        {
            Shuffle(placePoints);

            for (int i = 0; i < coins.Length; i++)
            {
                coins[i].position = placePoints[i].position;
                coins[i].gameObject.SetActive(true);
            }
        }

        private void Shuffle(Transform[] points)
        {
            for (int i = 0; i < points.Length; i++)
            {
                Transform tmp = points[i];
                int r = Random.Range(i, points.Length);
                points[i] = points[r];
                points[r] = tmp;
            }
        }
    }
}