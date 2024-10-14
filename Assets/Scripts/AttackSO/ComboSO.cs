using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "AttackSystem/Combo")]
public class ComboSO : ScriptableObject
{
    public List<AttackSO> ComboList;
}
