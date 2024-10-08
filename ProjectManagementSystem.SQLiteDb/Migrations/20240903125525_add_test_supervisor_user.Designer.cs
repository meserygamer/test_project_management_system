﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectManagementSystem.SQLiteDb;

#nullable disable

namespace ProjectManagementSystem.SQLiteDb.Migrations
{
    [DbContext(typeof(ProjectManagementSystemSQLiteDbContext))]
    [Migration("20240903125525_add_test_supervisor_user")]
    partial class add_test_supervisor_user
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("ProjectManagementSystem.SQLiteDb.Entities.ChangeOfTaskStatusEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ChangeDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("NewStatusId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TaskId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("NewStatusId");

                    b.HasIndex("TaskId");

                    b.HasIndex("UserId");

                    b.ToTable("ChangesOfTasksStatus", (string)null);
                });

            modelBuilder.Entity("ProjectManagementSystem.SQLiteDb.Entities.ProjectTaskEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ResponsibleUserId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("TaskStatusId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ResponsibleUserId");

                    b.HasIndex("TaskStatusId");

                    b.ToTable("ProjectTasks", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Написать маппер из класса UserEntity (Database) в User (Core)",
                            ResponsibleUserId = 1,
                            StartTime = new DateTime(2024, 9, 3, 15, 55, 24, 573, DateTimeKind.Local).AddTicks(7206),
                            TaskStatusId = 1,
                            Title = "Написать мапперы для пользователя"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Написать класс UserEntity отображающий пользователя в БД и конфигурацию UserConfiguration",
                            ResponsibleUserId = 1,
                            StartTime = new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Local),
                            TaskStatusId = 2,
                            Title = "Написать сущность и конфигурацию для хранения пользователей"
                        });
                });

            modelBuilder.Entity("ProjectManagementSystem.SQLiteDb.Entities.TaskStatusEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TaskStatuses", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Не в работе"
                        },
                        new
                        {
                            Id = 2,
                            Title = "В работе"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Заблокировано"
                        },
                        new
                        {
                            Id = 4,
                            Title = "Готово"
                        },
                        new
                        {
                            Id = 5,
                            Title = "Удалено"
                        });
                });

            modelBuilder.Entity("ProjectManagementSystem.SQLiteDb.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique()
                        .HasDatabaseName("LoginIndex");

                    b.HasIndex("UserRoleId");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "test@mail.com",
                            HashedPassword = "$2a$11$BS71wMsMq7URQ8UQbbBcMOWMBrc9.0MO2Wm8QhUtmJFLqhZqtBjJC",
                            Login = "Employee",
                            Name = "Работник",
                            Patronymic = "Работникович",
                            Surname = "Работников",
                            UserRoleId = 2
                        },
                        new
                        {
                            Id = 2,
                            Email = "test@mail.com",
                            HashedPassword = "$2a$11$BS71wMsMq7URQ8UQbbBcMOWMBrc9.0MO2Wm8QhUtmJFLqhZqtBjJC",
                            Login = "Supervisor",
                            Name = "Управляющий",
                            Patronymic = "Управляющевич",
                            Surname = "Управ",
                            UserRoleId = 1
                        });
                });

            modelBuilder.Entity("ProjectManagementSystem.SQLiteDb.Entities.UserRoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Управляющий"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Обычный сотрудник"
                        });
                });

            modelBuilder.Entity("ProjectManagementSystem.SQLiteDb.Entities.ChangeOfTaskStatusEntity", b =>
                {
                    b.HasOne("ProjectManagementSystem.SQLiteDb.Entities.TaskStatusEntity", "NewStatus")
                        .WithMany("ChangesTasksStatus")
                        .HasForeignKey("NewStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectManagementSystem.SQLiteDb.Entities.ProjectTaskEntity", "Task")
                        .WithMany("ChangesStatusHistory")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectManagementSystem.SQLiteDb.Entities.UserEntity", "User")
                        .WithMany("ChangesTasksStatus")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NewStatus");

                    b.Navigation("Task");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjectManagementSystem.SQLiteDb.Entities.ProjectTaskEntity", b =>
                {
                    b.HasOne("ProjectManagementSystem.SQLiteDb.Entities.UserEntity", "ResponsibleUser")
                        .WithMany("Tasks")
                        .HasForeignKey("ResponsibleUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectManagementSystem.SQLiteDb.Entities.TaskStatusEntity", "TaskStatus")
                        .WithMany("Tasks")
                        .HasForeignKey("TaskStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ResponsibleUser");

                    b.Navigation("TaskStatus");
                });

            modelBuilder.Entity("ProjectManagementSystem.SQLiteDb.Entities.UserEntity", b =>
                {
                    b.HasOne("ProjectManagementSystem.SQLiteDb.Entities.UserRoleEntity", "UserRole")
                        .WithMany("Users")
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("ProjectManagementSystem.SQLiteDb.Entities.ProjectTaskEntity", b =>
                {
                    b.Navigation("ChangesStatusHistory");
                });

            modelBuilder.Entity("ProjectManagementSystem.SQLiteDb.Entities.TaskStatusEntity", b =>
                {
                    b.Navigation("ChangesTasksStatus");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("ProjectManagementSystem.SQLiteDb.Entities.UserEntity", b =>
                {
                    b.Navigation("ChangesTasksStatus");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("ProjectManagementSystem.SQLiteDb.Entities.UserRoleEntity", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
