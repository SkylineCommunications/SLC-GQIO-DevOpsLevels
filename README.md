# SLC-GQIO-DevOpsLevels
The GQI Custom Operator is designed to enhance your data processing by adding a new column that represents the DevOps Level based on the existing column containing DevOps Points. This operator is particularly useful for mapping DevOps points to specific DevOps levels, providing valuable insights into your data.

## Usage

1. **Column Mapping:**
   - Ensure that your dataset includes a column containing DevOps Points.

2. **Apply Custom Operator:**
   - Use the GQI Custom Operator to add a new column representing the DevOps Level based on the existing points.

3. **DevOps Levels:**
   - The custom operator maps points to the following DevOps Levels:
     - Member
     - Advocate
     - Enabler
     - Catalyst

## Example

Consider the following dataset:

DevOps Points | DevOps Level
--------------|--------------
100           | Member
750           | Advocate
5000          | Enabler
25000         | Catalyst

In this example, the custom operator has successfully mapped DevOps points to their corresponding DevOps levels based on the following ranges:

- **Member:** 0 to 749
- **Advocate:** 750 to 4999
- **Enabler:** 5000 to 24999
- **Catalyst:** 25000 and above
