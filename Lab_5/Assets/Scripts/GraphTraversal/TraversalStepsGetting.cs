using Assets.Scripts.GraphComponents;
using System.Collections.Generic;

namespace Assets.Scripts.GraphTraversal
{
    /// <summary>
    /// Класс для получения шагов обхода графа.
    /// </summary>
    public class TraversalStepsGetting
    {
        /// <summary>
        /// Метод для получения шагов обхода графа в глубину.
        /// </summary>
        /// <param name="graph">Копия графа для обхода в глубину.</param>
        public static List<TraversalStep> GetDepthFirstSteps(Graph graph)
        {

            /* Ваш кодик должен быть туть
             * Поля, которые могут понадобиться:
             * graph.Points[index].LinkedLines 
             * Метод для проверки точки на то, является она начальной или конечной в указанной линии: point.IsStartPoint(Line line); */
            return new List<TraversalStep>();
        }

        /// <summary>
        /// Метод для получения шагов обхода графа в ширину.
        /// </summary>
        /// <param name="graph">Копия графа для обхода в ширину.</param>
        public static List<TraversalStep> GetBreadthFirstSteps(Graph graph)
        {
            List<TraversalStep> steps = new();

            List<Point> visited = new();
            visited.Add(graph.Points[0]);

            Queue<Point> queue = new();
            queue.Enqueue(graph.Points[0]);

            Point previousPoint = null;

            List<Line> lightedOnLines = new();
            List<Line> lightedOffLines = new();
            while (queue.Count > 0)
            {
                Point currentPoint = queue.Dequeue();
                if (previousPoint != null)
                {
                    foreach(Line line in currentPoint.LinkedLines)
                    {
                        if(previousPoint.IsStartPoint(Line line))
                        {
                            lightedOnLines.Add(line);
                            steps.Add(new TraversalStep(lightedOnLines, lightedOffLines,
                                "тест",
                                "тоже тест"));
                            break;
                        }
                    }
                }

                previousPoint = currentPoint;

                foreach (Line line in currentPoint.LinkedLines)
                {
                    foreach(Point graphPoint in graph.Points)
                    {
                        if (line.EndPosition == graphPoint.Position && !visited.Contains(graphPoint))
                        {
                            queue.Enqueue(graphPoint);
                            visited.Add(graphPoint);
                        }
                    }
                }
            }
            return steps;



            /* Ваш кодик должен быть туть
             * Поля, которые могут понадобиться:
             * graph.Points[index].LinkedLines
             * Метод для проверки точки на то, является она начальной или конечной в указанной линии: point.IsStartPoint(Line line); */
        }
    }
}