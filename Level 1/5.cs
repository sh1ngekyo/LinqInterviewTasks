Console.WriteLine(string.Join(", ", "aaa;abb;ccc;dap".Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Where(x => x.Contains('a')).Select(x => x.Count(y => y == 'a'))));