-- Development sample data: inserts 20 departments if their names do not already exist.
-- Run after applying the database migrations. The CreatedAt column uses its database default.
SET XACT_ABORT ON;
BEGIN TRANSACTION;

INSERT INTO dbo.Departments (Name, Description, Location, [Limit])
SELECT seed.Name, seed.Description, seed.Location, seed.[Limit]
FROM (VALUES
    (N'Engineering', N'Builds and maintains products and services.', N'Seattle', 80),
    (N'Human Resources', N'Recruiting, employee relations, and workplace programs.', N'Portland', 25),
    (N'Finance', N'Accounting, budgeting, and financial planning.', N'Chicago', 30),
    (N'Marketing', N'Brand strategy, campaigns, and market research.', N'New York', 35),
    (N'Sales', N'Customer acquisition and account management.', N'Austin', 60),
    (N'Customer Support', N'Customer service and technical support.', N'Denver', 45),
    (N'Information Technology', N'Internal systems, infrastructure, and security.', N'San Jose', 40),
    (N'Operations', N'Day-to-day business operations and process improvement.', N'Atlanta', 50),
    (N'Product Management', N'Product planning, prioritization, and delivery.', N'Boston', 20),
    (N'Legal', N'Contracts, compliance, and legal services.', N'Washington', 15),
    (N'Research and Development', N'Research, prototyping, and innovation.', N'San Diego', 32),
    (N'Quality Assurance', N'Software and process quality validation.', N'Phoenix', 24),
    (N'Design', N'User experience, user interface, and visual design.', N'Los Angeles', 18),
    (N'Logistics', N'Supply chain, shipping, and inventory coordination.', N'Miami', 28),
    (N'Procurement', N'Purchasing and supplier relationship management.', N'Dallas', 16),
    (N'Facilities', N'Office services, maintenance, and workplace safety.', N'Charlotte', 14),
    (N'Data and Analytics', N'Data engineering, reporting, and business intelligence.', N'San Francisco', 22),
    (N'Communications', N'Internal communications and public relations.', N'Nashville', 12),
    (N'Learning and Development', N'Employee training and professional development.', N'Minneapolis', 17),
    (N'Compliance', N'Regulatory monitoring, controls, and policy assurance.', N'Philadelphia', 13)
) AS seed(Name, Description, Location, [Limit])
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.Departments AS existing
    WHERE existing.Name = seed.Name
);

COMMIT TRANSACTION;
