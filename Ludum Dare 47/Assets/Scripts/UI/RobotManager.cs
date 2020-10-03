using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void RobotAddedEvent();
public delegate void RobotRemovedEvent();

public class RobotManager : MonoBehaviour
{
    [SerializeField]
    private GameObject robotPrefab;

    [SerializeField]
    private Button addRobotButton = null;
    [SerializeField]
    private InputField lineToAddRobotToField = null;

    [SerializeField]
    private Button removeRobotButton = null;
    [SerializeField]
    private InputField idOfRobotToRemoveField = null;

    [SerializeField]
    private Transform robotContainer = null;
    [SerializeField]
    private Transform robotSpawnPointOfReference;

    public event RobotAddedEvent OnRobotAdd;
    public event RobotRemovedEvent OnRobotRemove;

    private int currentNumberOfRobotsInPlay = 0;

    public void AddRobot()
    {
        if(currentNumberOfRobotsInPlay < DependencyContainer.Instance.Get<GlobalVariables>().NumberOfRobotsPerPlayer)
        {
            int line = int.Parse(lineToAddRobotToField.text);

            Vector3 spawnPos = robotSpawnPointOfReference.position;
            spawnPos.y -= line;
            GameObject robot = Instantiate(robotPrefab, spawnPos, Quaternion.identity, robotContainer);

            currentNumberOfRobotsInPlay++;
            robot.name = $"Robot{currentNumberOfRobotsInPlay}";

            OnRobotAdd?.Invoke();
        }
    }

    public void RemoveRobot()
    {
        //This is not accounting for which team the robot is on!
        if(currentNumberOfRobotsInPlay > 0)
        {
            int robotID = int.Parse(idOfRobotToRemoveField.text);

            GameObject robot = robotContainer.Find($"Robot{robotID}").gameObject;
            Destroy(robot);
            currentNumberOfRobotsInPlay--;

            OnRobotRemove?.Invoke();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
