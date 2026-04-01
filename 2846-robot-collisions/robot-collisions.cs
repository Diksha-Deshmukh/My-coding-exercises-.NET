using System;
using System.Collections.Generic;
using System.Linq;


//Diksha 

public class Solution {
    public IList<int> SurvivedRobotsHealths(int[] positions, int[] healths, string directions) {
        int n = positions.Length;
        
        // Create robot list: position, health, direction, original index
        var robots = new List<(int pos, int health, char dir, int idx)>();
        
        for (int i = 0; i < n; i++) {
            robots.Add((positions[i], healths[i], directions[i], i));
        }
        
        // Sort by position
        robots.Sort((a, b) => a.pos.CompareTo(b.pos));
        
        Stack<int> stack = new Stack<int>(); // store indices of robots list
        
        for (int i = 0; i < n; i++) {
            if (robots[i].dir == 'R') {
                stack.Push(i);
            } else {
                // direction == 'L'
                while (stack.Count > 0 && robots[i].health > 0) {
                    int top = stack.Peek();
                    
                    if (robots[top].health < robots[i].health) {
                        // top robot dies
                        robots[i] = (robots[i].pos, robots[i].health - 1, robots[i].dir, robots[i].idx);
                        robots[top] = (robots[top].pos, 0, robots[top].dir, robots[top].idx);
                        stack.Pop();
                    }
                    else if (robots[top].health == robots[i].health) {
                        // both die
                        robots[top] = (robots[top].pos, 0, robots[top].dir, robots[top].idx);
                        robots[i] = (robots[i].pos, 0, robots[i].dir, robots[i].idx);
                        stack.Pop();
                        break;
                    }
                    else {
                        // current robot dies
                        robots[top] = (robots[top].pos, robots[top].health - 1, robots[top].dir, robots[top].idx);
                        robots[i] = (robots[i].pos, 0, robots[i].dir, robots[i].idx);
                        break;
                    }
                }
            }
        }
        
        // Collect survivors and sort by original index
        var result = robots
            .Where(r => r.health > 0)
            .OrderBy(r => r.idx)
            .Select(r => r.health)
            .ToList();
        
        return result;
    }
}