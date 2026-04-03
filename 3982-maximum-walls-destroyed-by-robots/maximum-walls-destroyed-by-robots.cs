public class Solution {
    public int MaxWalls(int[] robots, int[] distance, int[] walls) {
        int n = robots.Length;
        int[] left = new int[n];
        int[] right = new int[n];
        int[] num = new int[n];
        Dictionary<int, int> robotsToDistance = new Dictionary<int, int>();

        for (int i = 0; i < n; i++) {
            robotsToDistance[robots[i]] = distance[i];
        }

        Array.Sort(robots);
        Array.Sort(walls);

        for (int i = 0; i < n; i++) {
            int pos1 = UpperBound(walls, robots[i]);

            int leftPos;
            if (i >= 1) {
                int leftBound = Math.Max(
                    robots[i] - robotsToDistance[robots[i]], robots[i - 1] + 1);
                leftPos = LowerBound(walls, leftBound);
            } else {
                leftPos =
                    LowerBound(walls, robots[i] - robotsToDistance[robots[i]]);
            }
            left[i] = pos1 - leftPos;

            int rightPos;
            if (i < n - 1) {
                int rightBound = Math.Min(
                    robots[i] + robotsToDistance[robots[i]], robots[i + 1] - 1);
                rightPos = UpperBound(walls, rightBound);
            } else {
                rightPos =
                    UpperBound(walls, robots[i] + robotsToDistance[robots[i]]);
            }
            int pos2 = LowerBound(walls, robots[i]);
            right[i] = rightPos - pos2;

            if (i == 0)
                continue;

            int pos3 = LowerBound(walls, robots[i - 1]);
            num[i] = pos1 - pos3;
        }

        int subLeft = left[0], subRight = right[0];
        for (int i = 1; i < n; i++) {
            int currentLeft =
                Math.Max(subLeft + left[i],
                         subRight - right[i - 1] +
                             Math.Min(left[i] + right[i - 1], num[i]));
            int currentRight =
                Math.Max(subLeft + right[i], subRight + right[i]);
            subLeft = currentLeft;
            subRight = currentRight;
        }

        return Math.Max(subLeft, subRight);
    }

    private int LowerBound(int[] arr, int target) {
        int left = 0, right = arr.Length;
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (arr[mid] < target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    }

    private int UpperBound(int[] arr, int target) {
        int left = 0, right = arr.Length;
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (arr[mid] <= target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    }
}