using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;

namespace KonnectNow.WebAPI.Infrastructure.Utilities
{
    /// <summary>
    /// Services response codes, messages for below supported HTTPStatusCodes 
    /// 200 - OK            (Success)
    /// 201 - Created       (Success)
    /// 400 - Bad Request   (Client Error)
    /// 401 - Unauthorized  (Client Error)
    /// 403 - Forbidden     (Client Error)
    /// 404 - NotFound      (Client Error)
    /// 500 - Internal Server Error (Server Error)
    /// </summary>
    public enum ResponseCodes
    {
        /// <summary>
        /// Success
        /// </summary>
        [HttpStatus(HttpStatusCode.OK)]
        [Description("Success")]
        OK = 2000,

        /// <summary>
        /// The request was processed successfully
        /// </summary>
        [HttpStatus(HttpStatusCode.Created)]
        [Description("The request was processed successfully")]
        CREATED = 2001,

        /// <summary>
        /// Invalid Or missing parameters
        /// </summary>
        [HttpStatus(HttpStatusCode.BadRequest)]
        [Description("Invalid Or missing parameters :")]
        INVALID_MISSING_INPUTS = 4000,

        /// <summary>
        /// Unauthorized Access.
        /// </summary>
        [HttpStatus(HttpStatusCode.Unauthorized)]
        [Description("Unauthorized access")]
        UNAUTHORIZED = 4001,

        /// <summary>
        /// Category already exist.
        /// </summary>
        [HttpStatus(HttpStatusCode.BadRequest)]
        [Description("Category already exist")]
        CATEGORY_ALREADY_EXIST = 4002,


        /// <summary>
        /// Category already exist.
        /// </summary>
        [HttpStatus(HttpStatusCode.NotFound)]
        [Description("Category not found")]
        CATEGORY_NOT_FOUND = 4003,
    }


    /// <summary>
    /// A base class for the singleton design pattern.
    /// </summary>
    /// <typeparam name="T">Class type of the singleton</typeparam>
    public abstract class SingletonBase<T> where T : class
    {
        #region Members

        /// <summary>
        /// Static instance. Needs to use lambda expression
        /// to construct an instance (since constructor is private).
        /// </summary>
        private static readonly Lazy<T> SInstance = new Lazy<T>(() => CreateInstanceOfT());

        #endregion

        #region Properties

        /// <summary>
        /// Gets the instance of this singleton.
        /// </summary>
        public static T Instance { get { return SInstance.Value; } }

        #endregion

        #region Methods

        /// <summary>
        /// Creates an instance of T via reflection since T's constructor is expected to be private.
        /// </summary>
        /// <returns></returns>
        private static T CreateInstanceOfT()
        {
            return Activator.CreateInstance(typeof(T), true) as T;
        }

        #endregion
    }
    /// <summary>
    /// Manages enum related operations
    /// </summary>
    public class EnumManager : SingletonBase<EnumManager>
    {
        private EnumManager()
        { }

        /// <summary>
        /// Get description of the enum members
        /// </summary>
        /// <typeparam name="T">Enum type</typeparam>
        /// <param name="enumData">Enum member data</param>
        /// <returns>Enum member description</returns>
        public string GetDescription<T>(T enumData)
        {
            FieldInfo fi = enumData.GetType().GetField(enumData.ToString());
            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : enumData.ToString();
        }

        /// <summary>
        /// Gets custom attribute value of the enum member.
        /// </summary>
        /// <typeparam name="T">Enum type</typeparam>
        /// <typeparam name="TR">Attribute type</typeparam>
        /// <typeparam name="TA"></typeparam>
        /// <param name="enumData">Enum Member</param>
        /// <returns></returns>
        public TR GetAttributeValue<T, TA, TR>(T enumData)
        {
            TR attributeValue = default(TR);

            var fi = enumData.GetType().GetField(enumData.ToString());

            if (fi != null)
            {
                var attributes = fi.GetCustomAttributes(typeof(TA), false) as TA[];

                if (attributes != null && attributes.Length > 0)
                {
                    var attribute = attributes[0] as IEnumAttribute<TR>;

                    if (attribute != null)
                    {
                        attributeValue = attribute.Value;
                    }
                }
            }
            return attributeValue;
        }
    }
    /// <summary>
    /// Custom attribute for all enums.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEnumAttribute<T>
    {
        /// <summary>
        /// Generic type Value.
        /// </summary>
        T Value { get; }
    }

    /// <summary>
    /// Custom attribute to declare HttpStatus.
    /// </summary>
    public sealed class HttpStatusAttribute : Attribute, IEnumAttribute<HttpStatusCode>
    {
        private readonly HttpStatusCode _value;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="value">HttpStatusCode value</param>
        public HttpStatusAttribute(HttpStatusCode value)
        {
            _value = value;
        }

        /// <summary>
        /// Gets HttpStatusCode value.
        /// </summary>
        public HttpStatusCode Value
        {
            get { return _value; }
        }
    }
}