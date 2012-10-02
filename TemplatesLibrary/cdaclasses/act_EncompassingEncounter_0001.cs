﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using nhs.itk.hl7v3.rim;
using nhs.itk.hl7v3.datatypes;
using nhs.itk.hl7v3.templates;
using nhs.itk.hl7v3.xml;
using nhs.itk.hl7v3.oids;
using System.Xml;

namespace nhs.itk.hl7v3.cda.classes
{
    internal class act_EncompassingEncounter_0001 : ActClass
    {
        internal string templateId { get; set; }
        internal string templateText { get; set; }

        internal p_location_000027 location;
        internal p_responsibleParty_000026 responsibleParty;
        internal List<p_participation_000028> participant;

        internal act_EncompassingEncounter_0001()
            : base()
        {
            base.ClassCode = "ENC";
            base.MoodCode = "EVN";
        }

        internal new void AddId(Guid guidValue)
        {
            base.AddId(guidValue);
        }

        internal new void SetEffectiveTime(IVLTS_Helper timeInterval)
        {
            base.SetEffectiveTime(timeInterval);
        }

        internal void SetLocation(NPFIT_000027_Role template)
        {
            location = new p_location_000027();
            location.Role = template;
        }

        internal void SetResponsibleParty(NPFIT_000026_Role template)
        {
            responsibleParty = new p_responsibleParty_000026();
            responsibleParty.role = template;
        }

        internal void AddParticipantTemplate(NPFIT_000028_Role template, p_participation_000028.EncounterParticipationType type)
        {
            if (participant == null) participant = new List<p_participation_000028>();

            p_participation_000028 thisParticipant = new p_participation_000028(type);
            thisParticipant.Role = template;

            participant.Add(thisParticipant);
        }

        internal void AddParticipantTemplate(NPFIT_000028_Role template, p_participation_000028.EncounterParticipationType type, IVLTS_Helper time)
        {
            if (participant == null) participant = new List<p_participation_000028>();

            p_participation_000028 thisParticipant = new p_participation_000028(type);
            thisParticipant.Role = template;
            thisParticipant.time = time.IVLTS;

            participant.Add(thisParticipant);
        }

        #region XML Members

        internal void WriteXml(XmlWriter writer)
        {

            writer.WriteStartElement("encompassingEncounter");

            base.SetTemplateId(OIDStore.OIDTemplatesTemplateId, templateId + "#" + "EncompassingEncounter");

            base.WriteXML(writer);

            if (responsibleParty != null)
            {
                writer.WriteStartElement("responsibleParty");
                responsibleParty.templateId = templateId;
                responsibleParty.WriteXml(writer);
                writer.WriteEndElement();
            }

            if (participant != null)
            {
                foreach (p_participation_000028 item in participant)
                {
                    writer.WriteStartElement("encounterParticipant");
                    item.TemplateId = templateId;
                    item.WriteXml(writer);
                    writer.WriteEndElement();
                }
            }

            if (location != null)
            {
                writer.WriteStartElement("location");
                location.templateId = templateId;
                location.WriteXml(writer);
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }

        #endregion
    }
}
