using ChatFlow.Domain.Aggregates.FlowAggregate.Buttons;
using ChatFlow.Domain.Aggregates.FlowAggregate.Nodes;
using ChatFlow.Modules.Nodes.Features.MapFlow.Options.ListButtonOption;

namespace ChatFlow.Modules.Nodes.Features.MapFlow.Mappers;

internal static class ListButtonMapper
{
    extension(ListButtonNode node)
    {
        public ListButtonOptionDto ToDto(string userPhone) =>
            new(To: userPhone, Interactive: node.ToInteractiveListButtonDto());

        private InteractiveListButtonDto ToInteractiveListButtonDto() => new(
            Body: node.ToBodyDto(),
            Action: node.ToActionListButtonDto(),
            Footer: node.FooterText.ToDto(),
            Header: node.HeaderText.ToDto()
        );

        private ActionListButtonDto ToActionListButtonDto() =>
            new(Button: node.ButtonText.Value, Sections: node.ToSectionListButtonDto());

        private List<SectionListButtonDto> ToSectionListButtonDto() =>
            node.SectionsButtons.Select(s => s.ToSectionListButtonDto()).ToList();
    }

    extension(SectionButton sectionButton)
    {
        private SectionListButtonDto ToSectionListButtonDto() => new(
            Title: sectionButton.Title, Rows: sectionButton.Rows.Select(r => r.ToRowDto()).ToList()
        );
    }

    extension(RowListButton row)
    {
        private RowDto ToRowDto() => new(Id: row.Id, Title: row.Title, Description: row.Description);
    }
}