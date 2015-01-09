using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//
//public class MonsterFSMAttackState : MonsterFSMState {
//	public static string STATE_NAME = "Attack";
//	protected float attack_ticket = 0;
//    private bool isAttackComplete = false;
//    
//	private int index = 0;
//	protected bool enum_action = true;
//	public override void enter (FSM fsm) {
//        
//        isAttackComplete = false;
//		index = 0;
//        enum_action = true;
//
//		BaseControlBehaviour target_cntl = null;
//		if (Zone.playerBeans != null)
//			target_cntl = PlayerControlBehaviour.findGameObject(Zone.playerBeans[0].getPlayerId());
//		else
//			target_cntl = Game.playerController;
//
//		Vector3 det = target_cntl.transform.position - this_fsm.cntl.transform.position;
//		det.z = 0;
//		float dist = det.magnitude;
//		Vector3 dir = det.normalized;
//
//		if (dir.x < 0)
//			this_fsm.cntl.changeOriToLeft();
//		else
//			this_fsm.cntl.changeOriToRight();
//
//        StartCoroutine("AttackGroup");
//		//SkillTemplate template = SkillConfig.findSkill("monsterbase");
//		
//		//if (template == null)
//		//	return;
//		
//		//SkillSequenceAction seq = this_fsm.cntl.gameObject.AddComponent<SkillSequenceAction>();
//		//seq.atoms = new List<SkillAtomTemplate>(template.atoms);
//		//seq.steps = new SkillTemplate[]{template};
//		//seq.enable();
//
//		attack_ticket = Time.time;
//	}
//
//
//	public override void update (FSM fsm) {
//        //if (Time.time - attack_ticket >= 3.0f)
//        //{
//			
//        //    if (this_fsm.cntl.hp > 0)
//        //        fsm.change(MonsterFSMStandState.STATE_NAME);
//        //}
//        if (this_fsm.cntl.hp > 0)
//        {
//            SkillSequenceAction sq = this_fsm.cntl.transform.GetComponent<SkillSequenceAction>();
//            if (isAttackComplete && this_fsm.cntl.transform.GetComponent<SkillSequenceAction>() == null)
//            {
//                fsm.change(this_fsm.RandowWithWeight());
//            }
//        }
//        else
//        {
//            fsm.change(MonsterFSMDeadState.STATE_NAME);
//        }
//
//	}
//	
//	public override void exit (FSM fsm) {
//		enum_action = false;
//
//		StopAllCoroutines();
//
//	}
//
//
//    IEnumerator AttackGroup()
//    {
//		MonsterFSM fsm = this_fsm;
//
//        List<Schemas.AiConfigSkillGroupEditor> group = AIConfigData.FindBySkillGroupId(this_fsm.traceAttackDoWhat.SkillGroupID.ToString());
//		while (enum_action && fsm.isAttack)
//        {
//            
//            //List<Schemas.AiConfigSkillGroupEditor> group = AIConfigData.getInstance().findBySkillGroupId(fsm.aiConfig.PlaceBehavior.TraceAttack[0].DoWhat[0].SkillGroupID.ToString());
//            if (index < group.Count)
//            {
//                if (index != 0)
//                {
//                    if (group[index].MotionID == "")
//                    {
//                        if (fsm.cntl.transform.GetComponent<SkillSequenceAction>() == null && !fsm.cntl.anim.IsPlaying(group[index - 1].MotionID))
//                        {
//                            AddSkill(fsm,group[index]);
//                        }
//                    }
//                    else
//                    {
//                        if (fsm.cntl.transform.GetComponent<SkillSequenceAction>() == null && !fsm.cntl.anim.IsPlaying(group[index - 1].MotionID))
//                        {
//							if (fsm.cntl.anim.GetClip(group[index].MotionID) != null)
//                           	 fsm.cntl.anim.Play(group[index].MotionID);
//                            index++;
//                        }
//                    }
//                }
//                else
//                {
//                    if (group[index].MotionID == "" || group[index].MotionID == null)
//                    {
//                        if (fsm.cntl.transform.GetComponent<SkillSequenceAction>() == null)
//                        {
//                            AddSkill(fsm,group[index]);
//                        }
//                    }
//                    else
//                    {
//                        if (fsm.cntl.transform.GetComponent<SkillSequenceAction>() == null)
//                        {
//							if(fsm.cntl.anim.GetClip(group[index].MotionID)!=null){
//								fsm.cntl.anim.Play(group[index].MotionID);
//							}
//                            index++;
//                        }
//                    }
//                }
//            }
//            else
//            {
//                isAttackComplete = true;
//                break;
//            }
//
//            yield return new WaitForSeconds(0.05f);
//        }
//    }
//
//    private void AddSkill(MonsterFSM fsm,Schemas.AiConfigSkillGroupEditor group)
//    {
//        SkillTemplate template = SkillConfig.findSkill(group.SkillID);
//
//        if (template == null)
//        {
//            //DebugUtil.LogWarning("为空跳出");
//            index++;
//            return;
//        }
//        SkillSequenceAction seq = fsm.cntl.gameObject.AddComponent<SkillSequenceAction>();
//        seq.atoms = new List<SkillAtomTemplate>(template.atoms);
//        seq.steps = new SkillTemplate[] { template };
//        seq.enable();
//		seq.skillId = group.SkillID;
//        index++;
//        //DebugUtil.LogWarning("攻击索引值：" + index);
//    }
//}
