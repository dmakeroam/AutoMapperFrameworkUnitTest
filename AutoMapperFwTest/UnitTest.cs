using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;
using AutoMapperFwTest.dto;
using AutoMapperFwTest.domain;
using System.Collections.Generic;

namespace AutoMapperFwTest
{
    [TestClass]
    public class UnitTest
    {

        public UnitTest()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<UserDTO, User>().ReverseMap());
        }

        [TestCategory("Mapper1")]
        [TestMethod]
        public void TestNormalMapper()
        {

            UserDTO dto = new UserDTO();
            dto.userId = "1";
            dto.firstName = "Oam";
            dto.lastName = "Kub";

            User user = Mapper.Map<UserDTO, User>(dto);

            Assert.AreEqual(dto.userId, user.userId);
            Assert.AreEqual(dto.firstName, user.firstName);
            Assert.AreEqual(dto.lastName, user.lastName);

        }

        [TestCategory("Mapper1")]
        [TestMethod]
        public void SwitchMapper()
        {
            User user = new User();
            user.userId = "1";
            user.firstName = "Oam";
            user.lastName = "Kub";

            UserDTO dto = Mapper.Map<User, UserDTO>(user);

            Assert.AreEqual(user.userId, dto.userId);
            Assert.AreEqual(user.firstName, dto.firstName);
            Assert.AreEqual(user.lastName, dto.lastName);
        }

        [TestCategory("Mapper1")]
        [TestMethod]
        public void TestListMapper()
        {

            List<UserDTO> dtoList = new List<UserDTO>();
            
            for(int i = 1; i <= 3; i++)
            {
                UserDTO dto = new UserDTO();
                dto.userId = ""+i;
                dto.firstName = "Oam" + i;
                dto.lastName = "Kub" + i;

                dtoList.Add(dto);
            }

            List<User> userList = Mapper.Map<List<UserDTO>, List<User>>(dtoList);

            for(int i = 0; i<3; i++)
            {
                Assert.AreEqual(userList[i].userId, dtoList[i].userId);
                Assert.AreEqual(userList[i].firstName, dtoList[i].firstName);
                Assert.AreEqual(userList[i].lastName, dtoList[i].lastName);
            }
        }

        [TestCategory("Mapper1")]
        [TestMethod]
        public void TestArrayMapper() {

            UserDTO[] dtoList = new UserDTO[3];

            for (int i = 0; i < 3; i++)
            {
                dtoList[i] = new UserDTO();
                dtoList[i].userId = "" + i;
                dtoList[i].firstName = "Oam" + i;
                dtoList[i].lastName = "Kub" + i;
            }

            User[] userList = Mapper.Map<UserDTO[], User[]>(dtoList);

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(userList[i].userId, dtoList[i].userId);
                Assert.AreEqual(userList[i].firstName, dtoList[i].firstName);
                Assert.AreEqual(userList[i].lastName, dtoList[i].lastName);
            }
        }
    }
}
