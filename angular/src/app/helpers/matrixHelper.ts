export function createMatrix<T>(cols: number, items: T[]): T[][] {
  const itemsMatrix: T[][] = [];

  for (let i = 0; i < items.length; i += cols) {
    itemsMatrix.push(items.slice(i, i + cols));
  }

  return itemsMatrix;
}
