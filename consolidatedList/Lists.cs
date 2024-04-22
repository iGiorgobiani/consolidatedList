using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists 
{
    public class Individual //Creating class of individual based on data of EU xml file
    {
        public string DATAID {  get; set; }
        public string VERSIONNUM { get; set; }
        public string FIRST_NAME { get; set; }
        public string SECOND_NAME { get; set; }
        public string THIRD_NAME { get; set; }
        public string UN_LIST_TYPE { get; set; }
        public string REFERENCE_NUMBER { get; set; }
        public string LISTED_ON { get; set; }
        public string NAME_ORIGINAL_SCRIPT { get; set; }
        public string COMMENTS1 { get; set; }
        public string TITLE { get; set; }
        public string DESIGNATION { get; set; }
        public string NATIONALITY { get; set; }
        public string LIST_TYPE { get; set; }
        public string LIST_DAY_UPDATED { get; set; }
        public string INDIVIDUAL_ALIAS { get; set; }
        public string INDIVIDUAL_ADDRESS { get; set; }
        public string DATE_OF_BIRTH { get; set; }
        public string PLACE_OF_BIRTH { get; set; }
    }

    public class Entity //Creating class of entity based on data of EU xml file
    {
        public string DATAID { get; set; }
        public string VERSIONNUM { get; set; }
        public string FIRST_NAME { get; set; }
        public string UN_LIST_TYPE { get; set; }
        public string REFERENCE_NUMBER { get; set; }
        public string LISTED_ON { get; set; }
        public string COMMENTS1 { get; set; }
        public string LIST_TYPE { get; set; }
        public string LIST_DAY_UPDATED { get; set; }
        public string ENTITY_ALIAS { get; set; } //ALIAS & ADDRESS MAY BE MORE THAN 1, needs to be addressed later
        public string ENTITY_ADDRESS { get; set; }
    }
}

namespace Inputs
{
    public class InputIndividual
    {
        public string FIRST_NAME { get; set; }
        public string SECOND_NAME { get; set; }
        public string THIRD_NAME { get; set; }
        public string NATIONALITY { get; set; }
        public string INDIVIDUAL_ADDRESS { get; set; }
        public string DATE_OF_BIRTH { get; set; }
        public string PLACE_OF_BIRTH { get; set; }

    }
}