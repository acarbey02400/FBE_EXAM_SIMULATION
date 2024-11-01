﻿using Core.Utilities;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISessionService
    {
        public IResult add(Session session);
        public IResult update(Session session);
        public IResult delete(Session session);
        public IDataResult<List<Session>> getAll();
        public IDataResult<Session> getById(int id);
        public IDataResult<Session> getByExamId(int id);
        public IDataResult<List<Session>> getByDateTime(DateTime dateTime);
        public IDataResult<List<SessionDetailDto>> getSessionDetails();
        public IResult CheckSessionTime(List<Lesson> lessons, int time);
    }
 

}


