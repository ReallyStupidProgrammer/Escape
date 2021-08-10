using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public static string message;
    public static Color messageColor;
    private RaycastHit hit;
    private GameObject current;

    private void Start() {
        message = "";
        messageColor = Color.clear;
    }

    bool getHit() {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast((Ray) ray, out hit);
    }

    private void rotateOperation(GameObject door) {
        if (door.tag == "locked") {
            GameObject key = door.GetComponent<Rotation>().relatedKey;
            string keyName;
            if (key == null) {
                keyName = "$$$";
            } else {
                keyName = key.name;
            }
            if (Item.selectedItemName != keyName) {
                message = Language.language["locked"].str;
                messageColor = Color.red;
            } else {
                message = Language.language["unlocked"].str;
                messageColor = Color.green;
                door.tag = "unlocked";
                ItemGUI.updateItemList(Item.selectedItemIndex);
                ItemGUI.resetSelected();
            }
        } else if (door.tag == "unlocked") {
            door.GetComponent<Rotation>().open();
        } 
    }

    private void moveOperation(GameObject drawer) {
        if (drawer.tag == "unlocked") {
            drawer.GetComponent<Movement>().move();
        } else {
            message = Language.language["locked"].str;
            messageColor = Color.red;
        }
    }

    private void pwdOperation(GameObject pwd) {
        pwd.GetComponent<Password>().add();
    }

    private void computerOperation(GameObject computer) {
        if (computer.tag == "NoPower") {
            message = Language.language["nopower"].str;
            messageColor = Color.red;
        }
    }
    
    private void keyHoleOperation(GameObject keyHole) {
        if (keyHole.GetComponent<KeyHole>().key.name == Item.selectedItemName) {
            keyHole.GetComponent<KeyHole>().plugin();
            ItemGUI.updateItemList(Item.selectedItemIndex);
            ItemGUI.resetSelected();
        }
    }

    private void rotateKeyOperation(GameObject key) {
        key.GetComponent<KeyRotate>().rotate();
    }

    private void itemOperation(GameObject item) {
        if (item.GetComponent<Item>().collected) return;
        item.GetComponent<Item>().collect();
        message = Language.language["getItem"].str + "\n" 
                + Language.language[item.GetComponent<Item>().objectName].str;
        messageColor = Color.green;
    }
    
    private void coverOperation(GameObject cover) {
        if (cover.tag == "unlocked") cover.GetComponent<Cover>().open();
        else {
            message = Language.language["locked"].str;
            messageColor = Color.red;
        }
    }

    private void screenOperation(GameObject screen) {
        if (screen.transform.parent.gameObject.tag == "NoPower") {
            message = Language.language["nopower"].str;
            messageColor = Color.red;
        }
        if (Item.selectedItemName == screen.GetComponent<Screen>().relatedItem.name) {
            screen.GetComponent<Screen>().crash();
            ItemGUI.updateItemList(Item.selectedItemIndex);
            ItemGUI.resetSelected();
        }
    }

    private void woodPlankOperation(GameObject woodPlank) {
        if (!Machine.machinePower) {
            message = Language.language["nopower"].str;
            messageColor = Color.red;
            return;
        }
        if (woodPlank.layer == 0) woodPlank.GetComponent<WoodPlank>().get();
        else woodPlank.GetComponent<WoodPlank>().put();
    }

    private void handleOperation(GameObject handle) {
        handle.GetComponent<Handle>().flush();
    }

    private void blackWaterOperation(GameObject blackWater) {
        if (Item.selectedItemName == "paper") {
            blackWater.GetComponent<BlackWater>().put();
        }
    }

    private void pipeOperation(GameObject pipe) {
        if ((pipe.GetComponent<Pipe>().CDPipe 
        && Item.selectedItemName == "CD")
        && Pipe.pipeDestroyed) {
            pipe.GetComponent<Pipe>().putCD();
            ItemGUI.updateItemList(Item.selectedItemIndex);
            ItemGUI.resetSelected();
        } else {
            pipe.GetComponent<Pipe>().removePipe();
        }

    }

    private void nailOperation(GameObject nail) {
        nail.GetComponent<Nail>().removeNail();
    }

    private void pianoKeyOperation(GameObject pianoKey) {
        pianoKey.GetComponent<PianoKey>().push();
    }

    private void lockOperation(GameObject suitecaseLock) {
        suitecaseLock.GetComponent<SuitecaseLock>().unlock();
    }

    private void ballOperation(GameObject ball) {
        ball.GetComponent<Ball>().operation();
    }

    private void lockHandleOperation(GameObject lockHandle) {
        lockHandle.GetComponent<WallControlBox>().open();
    }

    private void pusherOperation(GameObject pusher) {
        pusher.GetComponent<Pusher>().push();
    }

    private float dist(float a, float b, float c, float d) {
        return (float) Math.Pow((Math.Pow((a - c), 2) + Math.Pow((b - d), 2)), 0.5);
    }


    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (!getHit()) return;
            current = hit.collider.gameObject;
        }
        if (current != null) {
            float d = dist(current.transform.position.x, current.transform.position.z, 
                           transform.position.x, transform.position.z);
            print(d);
            if (current.name.IndexOf("Door") >= 0 
            || current.name.IndexOf("handle") >= 0) {
                rotateOperation(current);
            } else if ((current.name.IndexOf("drawer") >= 0 || current.name == "plug") 
                    || (current.name == "waterCover" || current.name == "carpet")) {
                moveOperation(current);
            } else if (current.name.IndexOf("cover") >= 0) {
                coverOperation(current);
            } else if (current.name == "closestoolHandle") {
                handleOperation(current);
            } else if (current.tag == "pluged") {
                rotateKeyOperation(current);
            } else if (current.name == "lockHandle") {
                lockHandleOperation(current);
            } else if (current.name == "pusher") {
                pusherOperation(current);
            } 
        } else 
            return;
        if (Input.GetMouseButtonUp(0)) {
            if (current.name.IndexOf("Pwd") >= 0) {
                pwdOperation(current);
            } else if (current.name.IndexOf("computer") >= 0) {
                computerOperation(current);
            } else if (current.name.IndexOf("KeyHole") >= 0) {
                keyHoleOperation(current);
            } else if (current.name.IndexOf("screen") >= 0) {
                screenOperation(current);
            } else if (current.name.IndexOf("machine") >= 0) {
                if (!Machine.machinePower) {
                    message = Language.language["nopower"].str;
                    messageColor = Color.red;
                }   
            } else if (current.name == "blackWater") {
                blackWaterOperation(current);
            } else if (current.name.IndexOf("pipe") >= 0) {
                pipeOperation(current);
            } else if (current.name.IndexOf("nail") >= 0) {
                nailOperation(current);
            } else if (current.tag == "item") {
                itemOperation(current);
            } else if (current.name.IndexOf("WoodPlank") >= 0) {
                woodPlankOperation(current);
            } else if (current.name.IndexOf("pianokey") >= 0) {
                pianoKeyOperation(current);
            } else if (current.name.IndexOf("Lock") >= 0) {
                lockOperation(current);
            } else if (current.tag == "ball") {
                ballOperation(current);
            }
            current = null;
        }

    }
}
