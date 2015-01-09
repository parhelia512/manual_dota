using UnityEngine;
using System.Collections;
//
//public class MonsterFSMStandState : MonsterFSMState
//{
//    public static string STATE_NAME = "Stand";
//
//    public override void enter(FSM fsm)
//    {
//        if(this_fsm == null)
//            return;
//        if(!this_fsm.cntl.edit)
//        {
//            this_fsm.idleBehavior = this_fsm.RandomIdle();
//            if(this_fsm.idleBehavior != null
//                && this_fsm.cntl.anim.GetClip(this_fsm.idleBehavior.MotionID) != null)
//            {
//                this_fsm.cntl.anim.Play(this_fsm.idleBehavior.MotionID);
//            }
//        }
//
//        if(this_fsm.hasAi)
//            StartCoroutine("action");
//    }
//    public override void update(FSM fsm)
//    {
//
//    }
//
//    public override void exit(FSM fsm)
//    {
//        StopAllCoroutines();
//    }
//
//    IEnumerator action()
//    {
//
//        while(true)
//        {
//
//            while(Game.paused)
//                yield return null;
//
//            yield return new WaitForSeconds(1.0f);
//
//            if(this_fsm.isCDAttack && this_fsm.traceAttackDoWhat != null)
//            {
//                if(this_fsm.traceAttackDoWhat.kingkongtype != null)
//                {
//                    ResourceHelper.LoadResource("effect/" + this_fsm.traceAttackDoWhat.kingkongtype, ResourceType.PREFAB, delegate(string name, Object res)
//                    {
//                        if(res != null)
//                        {
//                            GameObject effect = GameObject.Instantiate(res) as GameObject; ;
//                            effect.transform.parent = transform;
//                            effect.transform.position = transform.position;
//                            DelayDestroyObjectAction action = effect.AddComponent<DelayDestroyObjectAction>();
//                            action.duration = 3.0f;
//                            action.enable();
//                            this_fsm.cntl.SetAperture(true);
//                            if(transform.GetComponent<MonsterFSMFloatState>().enabled == false)
//                            {
//                                if(this_fsm.cntl.anim.GetClip("kingkong") != null)
//                                    this_fsm.cntl.anim.Play("kingkong");
//                            }
//                        }
//                    });
//                }
//                this_fsm.change(MonsterFSMCDAttackState.STATE_NAME);
//            }
//            else
//            {
//                if(Game.playerController.hp > 0)
//                {
//                    string temp = this_fsm.RandowWithWeight();
//                    this_fsm.change(temp);
//                }
//                else
//                {
//                    this_fsm.change(MonsterFSMStandState.STATE_NAME);
//                }
//            }
//            break;
//
//        }
//    }
//
//}
