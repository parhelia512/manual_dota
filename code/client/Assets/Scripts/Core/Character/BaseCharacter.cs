//
// /**************************************************************************
//
// BaseCharacter.cs
//
// Author: xiaohong  <704872627@qq.com>
//
// Date: 14-12-24
//
// Description: 角色它也有一些自己的特色，它有名称、等级、经验等等，
//				对于经验这个属性我还没有想好要不要放在这里，
//				因为我想让Enemy也继承这个类对于Enemy，它是有经验的，那是给予杀死它的玩家的
//				角色装备是否该放在这个类里面，装备模型，材质等
//
// Copyright (c) 2014 xiaohong
//
// **************************************************************************/
using UnityEngine;
using System.Collections;

public class BaseCharacter : MonoBehaviour
{
		private string _name;
		private int _level;
		private uint _freeExp;
		private uint _maxExp;

		/// <summary>
		/// Awake this instance.
		/// </summary>
		public virtual void Awake ()
		{
				_name = string.Empty;
				_level = 0;
				_freeExp = 0;

		}

		//public function

	#region Base Character Attribute Setters and Getters

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name {
				get{ return _name; }
				set{ _name = value; }
		}

		/// <summary>
		/// Gets or sets the level.
		/// </summary>
		/// <value>The level.</value>
		public int Level {
				get{ return _level; }
				set{ _level = value; }
		}

		/// <summary>
		/// Gets or sets the free exp.
		/// </summary>
		/// <value>The free exp.</value>
		public uint FreeExp {
				get{ return _freeExp; }
				set{ _freeExp = value; }
		}

		/// <summary>
		/// Gets the max exp.
		/// </summary>
		/// <value>The max exp.</value>
		public uint MaxExp {
				get{ return _maxExp; }
		}

	#endregion

	#region Add Character Exp

		/// <summary>
		/// Adds the exp.
		/// public function 
		/// </summary>
		/// <param name="exp">Exp.</param>
		public void AddExp (uint exp)
		{
				_freeExp += exp;
				CalculateLevel ();
		}

	#endregion
	
		//private function

	
		/// <summary>
		/// Stats the update.
		/// 角色等级改变属性变化后计算技能和生命受关联的属性值
		/// </summary>
		private void StatUpdate ()
		{

		}


	#region Calculate Character Lv and Update _maxExp
	
		private void CalculateLevel ()
		{
				while (_freeExp >= _maxExp) {
						_freeExp -= _maxExp;
						_level ++;
			
						StatUpdate ();
				}
		}
	
	#endregion
}
