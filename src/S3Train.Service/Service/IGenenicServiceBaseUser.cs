using System;
using System.Collections.Generic;
using S3Train.Domain;

namespace S3Train.Service
{
    public interface IGenenicServiceBaseUser<T> where T : ApplicationUser
    {
        /// <summary>
        /// Select all data
        /// </summary>
        /// <returns></returns>
        List<T> SelectAll();

        /// <summary>
        /// Get entity by Id, return null if not found
        /// </summary>
        /// <param name="id">The identifier.</param>
        T GetById(string id);
    }
}
