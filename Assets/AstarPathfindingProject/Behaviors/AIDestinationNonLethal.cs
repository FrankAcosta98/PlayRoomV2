using System.Drawing;
using System.Diagnostics.Contracts;
using UnityEngine;
using System.Collections;

namespace Pathfinding
{

    [UniqueComponent(tag = "ai.destination")]

    public class AIDestinationNonLethal : VersionedMonoBehaviour
    {
        /// <summary>The object that the AI should move to</summary>
        [HideInInspector] public Transform target;
        [Header("Points")]
        public Transform[] targets;
        public float delay = 1f;
        int index;
        float switchTime = float.PositiveInfinity;

        [Header("Hunt")]
        public float chill = 2f;
        private bool chilling = false;
        private float chillLevel = 0f;
        IAstarAI ai;
        void Start()
        {
            target = targets[index];
        }
        void OnEnable()
        {
            ai = GetComponent<IAstarAI>();
            // Update the destination right before searching for a path as well.
            // This is enough in theory, but this script will also update the destination every
            // frame as the destination is used for debugging and may be used for other things by other
            // scripts as well. So it makes sense that it is up to date every frame.
            if (ai != null) ai.onSearchPath += Update;
        }

        void OnDisable()
        {
            if (ai != null) ai.onSearchPath -= Update;
        }

        /// <summary>Updates the AI's destination every frame</summary>
        void Update()
        {
            //Debug.Log(chillLevel);
            if ((target.name == "Player" && ai != null) && (Vector2.Distance(target.position, gameObject.transform.position) > 2.53f)) ai.destination = target.position;
            if ((target.name == "Player" && ai != null) && Vector2.Distance(target.position, gameObject.transform.position) < 2.53f)
            {
                //MainChar.instace.GetComponent<SpriteRenderer>().enabled = false;
            }
            if (target.name != "Player")
            {

                if (targets.Length == 0) return;

                bool search = false;

                // Note: using reachedEndOfPath and pathPending instead of reachedDestination here because
                // if the destination cannot be reached by the agent, we don't want it to get stuck, we just want it to get as close as possible and then move on.
                if (ai.reachedEndOfPath && !ai.pathPending && float.IsPositiveInfinity(switchTime))
                {
                    switchTime = Time.time + delay;
                }

                if (Time.time >= switchTime)
                {
                    index = index + 1;
                    search = true;
                    switchTime = float.PositiveInfinity;
                }

                index = index % targets.Length;
                ai.destination = targets[index].position;

                if (search) ai.SearchPath();
            }
        }
        void FixedUpdate()
        {
            if (target.name == "Player" && chilling)
            {
                if (chillLevel < chill)
                    chillLevel += Time.fixedDeltaTime;
                if (chillLevel >= chill && target.name == "Player")
                    target = targets[index];
            }
        }
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.name == "Player")
            {
                chilling = false;
                chillLevel = 0f;
                target = other.gameObject.transform;
            }
        }
        void OnTriggerExit2D(Collider2D other)
        {
            if (other.name == "Player")
                chilling = true;
        }
    }
}
