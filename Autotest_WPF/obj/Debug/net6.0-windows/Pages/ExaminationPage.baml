   M S B A M L   `   `   `  ????G  CAutotest_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Autotest_WPFAutotest_WPF  5      "    Autotest_WPF.ExaminationPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Autotest_WPF     5        N? 
Background
  ??·? N? Title$ ExaminationPage??5	       ? 	Resources 5
         ChoiceButton ?? 
TargetType ?? Property ?? Value??%?   &	        ?? 5   
   " ??6%   .?5      ??  ? ??$ 20(?6)   ?? 5       ? ??$ 5q?6'   ?? 5       ? ??$
 Wrap=?67   5      5      .??5      ? .+?5   
   ?? -   5         ??Name$
 Exam??5      .+?5      ?? -   5        $??Ticket??5      $??40??6#   $	??Top=?6/   $??Center=?6G   $??20(?6d   6t   ?? 5      $??Visible=?6   .??5      ?? -   5        $ QuestionIndexButton??5      $
??Left=?6:    ?? Orientation$ 
Horizontal=?6V   5      5      ?? 5      -   5         ??Name$ QuestionImage??5      $??10q?6+   $	??300??67   $	??200??6C   $??/car.jpg??6P   ?? 5      -   5        $??	SavolText??5      $
??Wrap=?6*   $??20(?6?   $??Bu yerda savol turadi??6M   6l   ?? 5      $	??150??6   $??Visible=?6(   .??5       ?? -   5        $ CHoicePanel??5       $	??200??6.   5"      5#      ]? 5$      .+?5%      ?? -   5        	 ??Name$
	 Back??5%      $
??Left=?6#   $??0,0,5,0q?6>   $
??Back??5&      $	??100??6&   $??40??62   
????? ?6Q   ?? 5'      -   5        $	 Result??5'      $??Right=?6%   $??0,0,10,0q?6A   $??Result??5(      $	??100??6&   $??40??62   
??? ? ?6j   5)      5*      ?? 5,   
   -	   5        $ ResultPanel??5,      $y?Hidden=?6*   .+?5-      ?? $??Question count??6   ?? 5.      -
   5        
 ??Name$
 QuestionsText??5.      ?? 5/      $??Correct answer count??6   ?? 50      -   5        $
 CorrectAnswers??50      51      52      54      