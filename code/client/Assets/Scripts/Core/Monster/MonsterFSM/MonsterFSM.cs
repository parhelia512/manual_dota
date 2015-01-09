using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//
//public class MonsterFSM : FSM {
//	public MonsterControlBehaviour cntl;
//	public bool hasAi = false;
//    public bool isAttack = false;
//    public bool isPatrol = false;
//    public bool isCDAttack = false;
//    public bool isKingKong = false;
//    public Schemas.AiConfigAI aiConfig = null;
//
//    public Schemas.AiConfigAIPlaceBehaviorTraceAttackDoWhat traceAttackDoWhat = null;
//    public Schemas.AiConfigAIPlaceBehaviorTrace placeBehaviorTrace = null;
//    public Schemas.AiConfigAIPlaceBehaviorIdleBehavior idleBehavior = null;
//
//    public List<Schemas.AiConfigAIPlaceBehaviorTraceAttackDoWhat> cdAttack = new List<Schemas.AiConfigAIPlaceBehaviorTraceAttackDoWhat>();
//    public List<Schemas.AiConfigAIPlaceBehaviorTraceAttackDoWhat> noCDAttack = new List<Schemas.AiConfigAIPlaceBehaviorTraceAttackDoWhat>();
//    public Dictionary<int, int> skillCount = new Dictionary<int, int>();
//    public Dictionary<int, int> skillCD = new Dictionary<int, int>(); 
//
//	public MonsterFSM (MonsterControlBehaviour cntl) {
//		this.cntl = cntl;
//
//		if (cntl.raw != null)
//		{         
//        	Schemas.MonsterConfigMonster monsterConfig = MonsterConfig.findById(cntl.raw.raw.id);
//            Schemas.CopyConfigCopy copyConfig = CopyConfigData.FindById(Game.curCopyId);
//            if (copyConfig.difficulty == CopyConstants.DIFFICULTY_NIGHTMARE)
//            {
//                aiConfig = AIConfigData.FindById(monsterConfig.horribleaiId);
//            }
//            else 
//            {
//                aiConfig = AIConfigData.FindById(monsterConfig.normalaiId);
//            }
//			
//            if(aiConfig!=null){
//                for (int i = 0; i < aiConfig.PlaceBehavior.TraceAttack[0].DoWhat.Length; i++)
//                {
//                    if (aiConfig.PlaceBehavior.TraceAttack[0].DoWhat[i].CD != 0)
//                    {
//                        cdAttack.Add(aiConfig.PlaceBehavior.TraceAttack[0].DoWhat[i]);
//                        skillCount.Add(aiConfig.PlaceBehavior.TraceAttack[0].DoWhat[i].SkillGroupID, 0);
//                        skillCD.Add(aiConfig.PlaceBehavior.TraceAttack[0].DoWhat[i].SkillGroupID, 0);
//                    }
//                    else
//                    {
//                        noCDAttack.Add(aiConfig.PlaceBehavior.TraceAttack[0].DoWhat[i]);
//                    }
//                }
//            }
//		}
//
//		states.Add(MonsterFSMStandState.STATE_NAME, cntl.gameObject.AddComponent<MonsterFSMStandState>());
//		states.Add(MonsterFSMWalkState.STATE_NAME, cntl.gameObject.AddComponent<MonsterFSMWalkState>());
//		states.Add(MonsterFSMAttackState.STATE_NAME, cntl.gameObject.AddComponent<MonsterFSMAttackState>());
//		states.Add(MonsterFSMDeadState.STATE_NAME, cntl.gameObject.AddComponent<MonsterFSMDeadState>());
//		states.Add(MonsterFSMWaitState.STATE_NAME, cntl.gameObject.AddComponent<MonsterFSMWaitState>());
//		states.Add(MonsterFSMWaitForNetState.STATE_NAME, cntl.gameObject.AddComponent<MonsterFSMWaitForNetState>());
//		states.Add(MonsterFSMPatrolState.STATE_NAME, cntl.gameObject.AddComponent<MonsterFSMPatrolState>());
//		states.Add(MonsterFSMHurtBackState.STATE_NAME, cntl.gameObject.AddComponent<MonsterFSMHurtBackState>());
//		states.Add(MonsterFSMFloatState.STATE_NAME, cntl.gameObject.AddComponent<MonsterFSMFloatState>());
//		states.Add(MonsterFSMFallState.STATE_NAME, cntl.gameObject.AddComponent<MonsterFSMFallState>());
//		states.Add(MonsterFSMCDAttackState.STATE_NAME, cntl.gameObject.AddComponent<MonsterFSMCDAttackState>());
//        states.Add(MonsterFSMClimbState.STATE_NAME, cntl.gameObject.AddComponent<MonsterFSMClimbState>());
//		currentState = states [MonsterFSMStandState.STATE_NAME];
//	}
//	
//	public FSMState getState(string name) {
//        if (string.IsNullOrEmpty(name))
//            name = MonsterFSMStandState.STATE_NAME;
//		if (!states.ContainsKey(name))
//		{
//			if (name == MonsterFSMStandState.STATE_NAME)
//				states.Add(MonsterFSMStandState.STATE_NAME, cntl.gameObject.AddComponent<MonsterFSMStandState>());
//			else if (name == MonsterFSMWalkState.STATE_NAME)
//				states.Add(MonsterFSMWalkState.STATE_NAME, cntl.gameObject.AddComponent<MonsterFSMWalkState>());
//			else if (name == MonsterFSMAttackState.STATE_NAME)
//				states.Add(MonsterFSMAttackState.STATE_NAME, cntl.gameObject.AddComponent<MonsterFSMAttackState>());
//			else if (name == MonsterFSMDeadState.STATE_NAME)
//				states.Add(MonsterFSMDeadState.STATE_NAME, cntl.gameObject.AddComponent<MonsterFSMDeadState>());
//			else if (name == MonsterFSMWaitState.STATE_NAME)
//				states.Add(MonsterFSMWaitState.STATE_NAME, cntl.gameObject.AddComponent<MonsterFSMWaitState>());
//			else if (name == MonsterFSMWaitForNetState.STATE_NAME)
//				states.Add(MonsterFSMWaitForNetState.STATE_NAME, cntl.gameObject.AddComponent<MonsterFSMWaitForNetState>());
//			else if (name == MonsterFSMPatrolState.STATE_NAME)
//				states.Add(MonsterFSMPatrolState.STATE_NAME, cntl.gameObject.AddComponent<MonsterFSMPatrolState>());
//			else if (name == MonsterFSMHurtBackState.STATE_NAME)
//				states.Add(MonsterFSMHurtBackState.STATE_NAME, cntl.gameObject.AddComponent<MonsterFSMHurtBackState>());
//			else if (name == MonsterFSMFloatState.STATE_NAME)
//				states.Add(MonsterFSMFloatState.STATE_NAME, cntl.gameObject.AddComponent<MonsterFSMFloatState>());
//			else if (name == MonsterFSMFallState.STATE_NAME)
//				states.Add(MonsterFSMFallState.STATE_NAME, cntl.gameObject.AddComponent<MonsterFSMFallState>());
//       		else if (name == MonsterFSMCDAttackState.STATE_NAME)
//				states.Add(MonsterFSMCDAttackState.STATE_NAME, cntl.gameObject.AddComponent<MonsterFSMCDAttackState>());
//		}
//		
//		return states[name];		
//	}
//
//	public override void change(string name) {
//			if (currentState != null)
//			{
//				currentState.exit(this);
//				((MonsterFSMState)currentState).enabled = false;
//			}
//			currentState = getState(name);
//			((MonsterFSMState)currentState).enabled = true;
//			((MonsterFSMState)currentState).this_fsm = this;
//			currentState.enter(this);
//	}
//
//    public string RandowWithWeight()
//    {
//        if (aiConfig == null)
//            return null;
//
//        int weight = aiConfig.PlaceBehavior.IdleWeight + aiConfig.PlaceBehavior.PatrolWeight + aiConfig.PlaceBehavior.TraceWeight + aiConfig.PlaceBehavior.TraceAttackWeight;
//
//        int random = Random.Range(0, weight);
//        //DebugUtil.Log("权重：" + random);
//        int temp = 0;
//        if (random < aiConfig.PlaceBehavior.IdleWeight)
//        {
//            isAttack = false;
//            return MonsterFSMStandState.STATE_NAME;
//            //DebugUtil.Log("Idle空闲");
//        }
//        else if (random < aiConfig.PlaceBehavior.IdleWeight + aiConfig.PlaceBehavior.PatrolWeight)
//        {
//            isAttack = false;
//            return MonsterFSMPatrolState.STATE_NAME;
//            //DebugUtil.Log("Patrol巡逻");
//        }
//        else if (random < aiConfig.PlaceBehavior.IdleWeight + aiConfig.PlaceBehavior.PatrolWeight + aiConfig.PlaceBehavior.TraceWeight)
//        {
//            isAttack = false;
//            return MonsterFSMWalkState.STATE_NAME;
//            //DebugUtil.Log("Trace追踪");
//        }
//        else
//        {
//            isAttack = true;
//            return MonsterFSMWalkState.STATE_NAME;
//            //DebugUtil.Log("TraceAttack追杀");
//        }
//
//        return null;
//    }
//
//    public Schemas.AiConfigAIPlaceBehaviorTraceAttackDoWhat RandomAttack()
//    {
//        int weight = 0;
//        int temp = 0;
//
//        for (int i = 0; i < noCDAttack.Count; i++)
//        {
//            weight += int.Parse(noCDAttack[i].SkillGroupWeight);        
//        }
//
//        int random = Random.Range(0, weight);
//        for (int i = 0; i < noCDAttack.Count; i++)
//        {
//            temp += int.Parse(noCDAttack[i].SkillGroupWeight);
//            if (random < temp)
//            {
//                return noCDAttack[i];
//            }
//        }
//        return null;
//    }
//
//    public Schemas.AiConfigAIPlaceBehaviorTrace RandomMove()
//    {
//        if (aiConfig == null)
//            return null;
//
//        int weight = 0;
//        int temp = 0;
//
//        for (int i = 0; i < aiConfig.PlaceBehavior.Trace.Length; i++)
//        {
//            weight += aiConfig.PlaceBehavior.Trace[i].MoveWeight;
//        }
//
//        int random = Random.Range(0, weight);
//        for (int i = 0; i < aiConfig.PlaceBehavior.Trace.Length; i++)
//        {
//            temp += aiConfig.PlaceBehavior.Trace[i].MoveWeight;
//            if (random < temp)
//            {
//                return aiConfig.PlaceBehavior.Trace[i];
//            }
//        }
//
//        return null;
//    }
//
//    public Schemas.AiConfigAIPlaceBehaviorIdleBehavior RandomIdle()
//    {
//        if (aiConfig == null)
//            return null;
//        int weight = 0;
//        int temp = 0;
//
//        for (int i = 0; i < aiConfig.PlaceBehavior.IdleBehavior.Length; i++)
//        {
//            weight += aiConfig.PlaceBehavior.IdleBehavior[i].MotionWeight;
//        }
//
//        int random = Random.Range(0, weight);
//        for (int i = 0; i < aiConfig.PlaceBehavior.IdleBehavior.Length; i++)
//        {
//            temp += aiConfig.PlaceBehavior.IdleBehavior[i].MotionWeight;
//            if (random < temp)
//            {
//                return aiConfig.PlaceBehavior.IdleBehavior[i];
//            }
//        }
//
//        return null;
//    }
//}
