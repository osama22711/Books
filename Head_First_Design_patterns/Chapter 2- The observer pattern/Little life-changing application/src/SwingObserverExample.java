import javax.swing.*;
import java.awt.event.*;
import java.awt.*;


public class SwingObserverExample {
	JFrame frame;
	
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		SwingObserverExample example = new SwingObserverExample();
		example.go();
	}
	
	public void go() {
		frame = new JFrame();
		JButton button = new JButton("Should i do it?");
		button.addActionListener(new AngelListener());
		button.addActionListener(new DevilListener());
		frame.getContentPane().add(BorderLayout.CENTER, button);
	}
	
	class AngelListener implements ActionListener {
		public void actionPerformed(ActionEvent event) {
			System.out.println("Don't do it, you might regret it!");
		}
	}
	
	class DevilListener implements ActionListener {
		public void actionPerformed(ActionEvent event) {
			System.out.println("Come on, do it!");
		}
	}

}
