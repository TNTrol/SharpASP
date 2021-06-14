using System;
using System.Collections.Generic;
using System.Linq;
using DTO;
using Model;

namespace WebApplication.Utils
{
    public class Filter
    {
        private readonly FilterModel _filter;

        public Filter(FilterModel filter)
        {
            _filter = filter;
        }

        public IList<FullCourseDTO> GetResult(IList<FullCourseDTO> list)
        {
            var date = new DateTime(2000, 6, 3);
            var date2 = new DateTime(2100, 6, 3);
            //var date2 = new DateTime(2000, 6, 3);
            if (_filter.To < date)
                _filter.To = date2;
            IList<FullCourseDTO> list1 = list;
            if(_filter.Name != null)
                list1 = list1.Where(c =>
                c.Lecturer.ToUpper().StartsWith(_filter.Name.ToUpper())).ToList();
            if(_filter.ExperienceDown > 0)
                list1 = list1.Where(c => c.Experience > _filter.ExperienceDown).ToList();
            if(_filter.ExperienceUp > 0)
                list1 = list1.Where(c => c.Experience < _filter.ExperienceUp).ToList();
            if(_filter.IdSubject > 0)
                list1= list1.Where(c => c.IdSubject == _filter.IdSubject).ToList();
            list1 = list1.Where(c => _filter.To > c.To && _filter.With < c.With).ToList();
            if (_filter.OrderBy != null)
                list1 = list1.OrderBy(c => c.Id).ToList();
            return list1;
        }
    }
}