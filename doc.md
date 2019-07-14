# Take Your Heart 说明文档

### 主要类介绍

#### Player类

​	各角色类的父类，包含：

``` c#
public virtual string PlayerName { get; }
```

只读属性，角色名。

```c#
public float Speed { get; set; }
```

控制移动速度

``` c#
public Directions Move(KeyCode up, KeyCode down, KeyCode left, KeyCode right)
```

角色的通用移动方法，参数为顺序上下左右移动按键，返回参数 Directions 为角色当前朝向枚举，定义为：

```c#
public enum Directions
{
    Stop,
    Up,
    UpRight,
    Right,
    DownRight,
    Down,
    DownLeft,
    Left,
    UpLeft,
}
```



``` c#
public int Trapped(GameObject Player, Collider2D Trap)
```

角色碰撞到陷阱时的通用方法

传入参数 GameObject Player 为角色物体本身； Collider2D Trap 为碰撞到的陷阱、

返回玩家分数变化



#### Trap类

​	各种陷阱的父类

``` c#
public virtual string TrapName { get; }
```

属性，陷阱名，只读

``` c#
public virtual int ScoreChange { get; }
```

碰撞陷阱后玩家发生的分数变化

``` c#
public virtual int Trapped(GameObject Player)
```

陷阱触发时由 Player 的Trapped方法调用

```c#
public void DestroyTrap()
```

陷阱的销毁方法



### 地图制作方法

* Position.cs 脚本

  每个地图由一个GameObject下包含任意数量物体，主GameObject下需挂载Position.cs脚本

  脚本中变量为

  1. 三名角色的初始位置
  2. 四个炮台的运动路线，路线为一系列用于定位的GameObject组成的数组，当路线为封闭时，将定位物体顺次填入即可，当路线不封闭时，需按顺序填入使炮台运动回初始位置的物体
  3. 心的初始位置

* 地图预制件内容

  预制件中需包含地图背景，墙体的碰撞盒，炮台路线的定位物体

